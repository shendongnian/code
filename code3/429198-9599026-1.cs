     public class ConfigurationService {
        
             private ConfigurationBase  CreateConfig1(string id, string name, string url, string referenceUrl){...}
        
             private ConfigurationBase  CreateConfig2(string id, string name, string domain, bool allowCookie){...}
        
             public ConfigudationBase CreateConfig( string id, string name, string domain, bool allowCookie, string url, string referenceUrl, ConfigType configTypeEnum){
              //call the expected factory method based on enum type.
             }
        }
