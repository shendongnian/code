    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class MyMessageHandler : NativeWindow
    {
        private event EventHandler<MyEventArgs> messageReceived;
        public event EventHandler<MyEventArgs> MessageReceived
        {
            add
            {
                if (messageReceived == null || !messageReceived.GetInvocationList().Contains(value))
                    messageReceived += value;
            }
            remove
            {
                messageReceived -= value;
            }
        }
        public MyMessageHandler()
        {
            var cp = new CreateParams();
            CreateHandle(cp);
        }
        
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message msg)
        {
            var handler = messageReceived;
            if (handler != null)
                handler(this, new MyEventArgs(msg));
            base.WndProc(ref msg);
        }
    }
