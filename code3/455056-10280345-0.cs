    public class SomeValueToBrushConverter : IValueConverter
    {
        public SomeValueToBrushConverter(){
          ConfigurationRepository = ServiceLocator.Current.GetInstance<ConfigurationRepository>();
        }
        private ConfigurationRepository ConfigurationRepository { get; set; }
    }
