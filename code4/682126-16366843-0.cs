    public class AViewModel // : Screen - that's optional right here ;)
    {
        private readonly BViewModel bViewModel;
        private readonly IWindowManager windowManager;
    
        public AViewModel(BViewModel bViewModel, IWindowManager windowManager)
        {
            this.bViewModel = bViewModel;
            this.windowManager = windowManager;
        }
    
        public void ShowB()
        {
            windowManager.ShowWindow(bViewModel); //If you want a modal dialog, then use ShowDialog that returns a bool?
        }
    }
