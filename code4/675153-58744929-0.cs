    public interface IMainWindowAccess
    {
        void Close(bool result);
    }
    public class MainWindow : IMainWindowAccess
    {
        // (...)
        public void Close(bool result)
        {
            DialogResult = result;
            Close();
        }
    }
    public class MainWindowViewModel
    {
        private IMainWindowAccess access;
        public MainWindowViewModel(IMainWindowAccess access)
        {
            this.access = access;
        }
        public void DoClose()
        {
            access.Close(true);
        }
    }
