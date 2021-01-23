    public class ViewModel
    {
        private readonly IWindowFactory m_windowFactory;
        private ICommand m_openNewWindow;
        public ViewModel(IWindowFactory windowFactory)
        {
            m_windowFactory = windowFactory;
            /**
             * Would need to assign value to m_openNewWindow here, and associate the DoOpenWindow method
             * to the execution of the command.
             * */
            m_openNewWindow = null;  
        }
        public void DoOpenNewWindow()
        {
            m_windowFactory.CreateNewWindow();
        }
        public ICommand OpenNewWindow { get { return m_openNewWindow; } }
    }
    public interface IWindowFactory
    {
        void CreateNewWindow();
    }
    public class ProductionWindowFactory: IWindowFactory
    {
        #region Implementation of INewWindowFactory
        public void CreateNewWindow()
        {
           NewWindow window = new NewWindow
               {
                   DataContext = new NewWindowViewModel()
               };
           window.Show();
        }
        #endregion
    }
