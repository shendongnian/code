    public class WindowClass
    {
        public WindowClass()
        {
           var messenger = ServiceLocator.Current.GetInstance<IMessenger>();
           messenger.Register<CloseWindowMessage>(this, _ => Close());
        }
    }
