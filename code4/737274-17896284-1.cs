    public class ConfigService : IConfigService
    {
        private string _ConfiguredPlan = string.Empty;
    
        public string ConfiguredPlan
        {
            get
            {
                if (string.IsNullOrEmpty(_ConfiguredPlan)){
                        //load configured plan from DB
                }
                return _ConfiguredPlan;
            }
        }
    }
