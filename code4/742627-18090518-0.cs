      public partial class App : Application
      {
        public App()
        {
          var def = Debug.Listeners["Default"];
          Debug.Listeners.Remove(def);
          Debug.Listeners.Add(new MyListener(def, Dispatcher.CurrentDispatcher));
        }
    
        private class MyListener : TraceListener
        {
          private TraceListener _defListener;
          private Dispatcher _guiDisp;
          public MyListener(TraceListener def, Dispatcher guiDisp) 
          { 
            _defListener = def;
            _guiDisp = guiDisp;
          }
          public override void Write(string message) { _defListener.Write(message); }
          public override void WriteLine(string message) { _defListener.WriteLine(message); }
    
          public override void Fail(string message, string detailMessage)
          {
            base.Fail(message, detailMessage);  //write message to the output panel
    
            if (Debugger.IsAttached)
            {
              //if debugger is attached, just break => all threads stopped
              Debugger.Break();
            }
            else if (Dispatcher.CurrentDispatcher == _guiDisp)
            {
              //running standalone and called in the GUI thread => block it
              Thread anotherGuiThread = new Thread(() =>
              {
                //TODO: nice dlg with buttons
                var assertDlg = new Window() { Width = 100, Height = 100 };
                assertDlg.Show();
                assertDlg.Closed += (s, e) => assertDlg.Dispatcher.InvokeShutdown();
                System.Windows.Threading.Dispatcher.Run();  //run on its own thread
              });
    
              anotherGuiThread.SetApartmentState(ApartmentState.STA);
              anotherGuiThread.Start();
              anotherGuiThread.Join();
            }
            else
            {
              //running standalone and NOT called in the GUI thread => call normal assert
              _defListener.Fail(message, detailMessage);
            }
          }
        }
      }
