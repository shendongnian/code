    public class ComLibrary
    {
        private static ComSettings _defaults = new ComSettings { Port = 80, Address = "localhost" };
        protected ComSettings settings;
        public ComLibrary(ComSettings pSettings)
        {
            this.settings = ObjectMerge<ComSettings>(_defaults, pSettings);
        }
    }
