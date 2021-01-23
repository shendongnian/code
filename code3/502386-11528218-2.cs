    public class MyLicensingHttpModule : IHttpModule
    {
        // Set when the application is initialized
        public static IsLicensed { get; private set; }
        public void Init(HttpApplication context)
        {
             // Check for licensing here.  Set
             // the flag accordingly.
             IsLicensded = <licensing condition>;
        }
    }
