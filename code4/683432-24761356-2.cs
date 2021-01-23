    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private readonly IWindowManager windowManager;
        public ShellViewModel()
        {
            this.windowManager = new WindowManager();
            this.windowManager.ShowWindow(new LameViewModel());
        }
    }
