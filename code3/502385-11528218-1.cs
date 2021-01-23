    public class MyLicensingHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
             // Check for licensing here.
             if (!<licensing condition>)
             {
                 // Bomb the app.
                 throw new InvalidOperationException("Component is not licensed.");
             }            
        }
    }
