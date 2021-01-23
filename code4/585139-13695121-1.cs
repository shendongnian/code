    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public delegate void CustomEventHandler(object sender, CustomEventArgs a);
        class Class1
        {
            public event EventHandler RaiseCustomEvent;
            public Class1()
            {
                Timer tmr = new Timer();
                tmr.Tick += new EventHandler(tmr_Tick);
                tmr.Interval = 2000;
                tmr.Start();
            }
            void tmr_Tick(object sender, EventArgs e)
            {
                CustomEventArgs ea = new CustomEventArgs("Hello World");
                RaiseCustomEvent(this, ea);
            }
        }
        public class CustomEventArgs : EventArgs
        {
            public CustomEventArgs(string s)
            {
                msg = s;
            }
            private string msg;
            public string Message
            {
                get { return msg; }
            }
        }
    }
