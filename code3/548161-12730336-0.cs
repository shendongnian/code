    public class GlobalConfig{
        /* your configuration properties here */
        private static GlobalConfig instance = null;
        public static GlobalConfig Instance{
            get{
                if(instance == null) instance=new GlobalConfig();
                return instance;
            }
        }
        private GlobalConfig(){ /* set default property values */ }
    }
