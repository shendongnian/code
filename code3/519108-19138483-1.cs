    public class MyWindowViewModel: ViewModelBase
    {
        public Command.StandardCommand CloseCommand
        {
            get
            {
                return new Command.StandardCommand(Close);
            }
        }
        public void Close()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }
    }
