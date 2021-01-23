    [Export(typeof(IBasePlugin))]
    public class Plugin : IBasePlugin
    {
        [Import]
        private IGORViewModel _viewModel { get; set; }
        private ResourceDictionary _viewDictionary = new ResourceDictionary();
    
        [ImportingConstructor]
        public Plugin()
        {
            // First we need to set up the View components.
            _viewDictionary.Source =
                new Uri("/Extension.MyPlugin;component/View.xaml",
                UriKind.RelativeOrAbsolute);
        }
    
        ....Properties...
    
    }
