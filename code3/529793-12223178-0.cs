    public partial class App : Application
    {
        [Import]
        public Window TheMainWindow { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var moduleCatalog = new AggregateCatalog(
                new AssemblyCatalog(typeof(App).Assembly), 
                new DirectoryCatalog(moduleDir));
            var container = new CompositionContainer(moduleCatalog);
            container.ComposeParts(this);
            base.MainWindow = TheMainWindow;
            TheMainWindow.Show();
        }
    }
