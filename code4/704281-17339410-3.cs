    // Example viewmodel:
    public class ModernWindowViewModel : Conductor<IScreen>.Collection.OneActive
    {
        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            // Instantiate a new navigation conductor for this window
            new FrameNavigationConductor(this);
        }
    }
