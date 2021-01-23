    [Export(typeof(IModule ))]
    public class SampleModule : IModule {
        private DataTemplate template;
        public DataTemplate IModule.Template {
            get { return this.teplate; }
            set { this.template = value; }
        }
        private string name = "SamplePlugin";
        public string  IModule.Name{
            get { return this.name ; }
            set { this.name = value; }
        }
        ...
    }
