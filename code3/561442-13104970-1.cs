    public class LandingView : UserControl, ILandingView
    {
        // Constructor
    
        public LandingView(... other dependencies here ...)
        {
        }
    
        // This property will be set by Autofac
        public ILandingPresenter Presenter { get; set; }
    }
