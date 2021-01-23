    public class WindowClass
    {
        public WindowClass()
        {
           var messenger = ServiceLocator.Get<IMessenger>();
           messenger.Register<CloseWindowMessage>(_ => Close());
        }
    }
