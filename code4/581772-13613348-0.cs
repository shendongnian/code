    [BuildActivity(HostEnvironmentOption.All)]
        public partial class SourceCodeAnalysisAsync : AsyncCodeActivity
        {
            private CodeActivityContext _context;
            private bool _continue = true;
    
            protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
            {
                _context = context;
                var  doSomethingDelegate = new Action(DoSomething);
                context.UserState = doSomethingDelegate;
                return doSomethingDelegate.BeginInvoke(callback, state);
            }
    
            protected override void Cancel(AsyncCodeActivityContext context)
            {
                base.Cancel(context);
                _continue = false;
            }
    
            protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
            {
                var doSomethingDelegate = (Action)context.UserState;
                doSomethingDelegate.EndInvoke(result);
            }
    
            private void DoSomething()
            {
                if (File.Exists(@"C:\test.txt"))
                {
                    File.Delete(@"C:\test.txt");
                }
    
                int i = 0;
                do
                {
                    File.AppendAllText(@"C:\test.txt", string.Format("do something {0}\r\n", i));
                    Thread.Sleep(1000);
                    i++;
                } while (_continue && i < 30);
            }
        }
