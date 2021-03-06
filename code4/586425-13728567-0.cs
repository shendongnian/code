    public class NewFrameAdapter : INavigationService
    {
        private readonly Frame frame;
        private readonly IConductActiveItem shell;
        private event NavigatingCancelEventHandler ExternalNavigatingHandler = delegate { };
        public FrameAdapter(Frame frame)
        {
            this.frame = frame;
            // Might want to tighten this up as it makes assumptions :)
            this.shell = (frame as FrameworkElement).DataContext as IConductActiveItem;
        }
        public bool Navigate(Type pageType)
        {
            // Do guardclose and deactivate stuff here by looking at shell.ActiveItem
            // e.g.
            var guard = shell.ActiveItem as IGuardClose;
            if (guard != null)
            {
                var shouldCancel = false;
                guard.CanClose(result => { shouldCancel = !result; });
                if (shouldCancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            // etc
                   
            // Obviously since the guard is async you'd have to not call this code right 
            // here but I've just stuck it in here as an example
            // You might get away with calling shell.ActivateItem(pageType) as I'm not sure
            // if the CM conductor in RT would resolve this for you, but if it doesnt...
            // Init the view and then resolve the VM type
            ViewLocator.InitializeComponent(pageType);
            var viewModel = ViewModelLocator.LocateForView(pageType);
            // Activate the VM in the shell)
            shell.ActivateItem(viewModel);
        }
