    public class Setup
        : MvxBaseAndroidBindingSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }
        protected override MvxApplication CreateApp()
        {
            return new App();
        }
        protected override IEnumerable<Type> ValueConverterHolders
        {
            get { return new[] { typeof(Converters.Converters) }; }
        }
    }
