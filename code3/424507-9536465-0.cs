    public class CustomWSFederationAuthenticationModule : WSFederationAuthenticationModule
    {
        protected override void InitializePropertiesFromConfiguration(string serviceName)
        {
            this.Realm = "http://localhost:81/";
            this.Issuer = "https://acsnamespace.accesscontrol.windows.net/v2/wsfederation";
            this.RequireHttps = false;
            this.PassiveRedirectEnabled = true;
        }
    }
