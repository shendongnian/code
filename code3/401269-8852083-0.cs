    [Activity(Label = "Location Demo")]
    public class LocationActivity : Activity, ILocationListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
    
            SetContentView(Resource.Layout.Main);
    
            var locationManager = (LocationManager)GetSystemService(LocationService);
    
            var criteria = new Criteria { Accuracy = Accuracy.NoRequirement };
            string bestProvider = locationManager.GetBestProvider(criteria, true);
    
            locationManager.RequestLocationUpdates(bestProvider, 5000, 2, this);
        }
    
        public void OnLocationChanged(Location location)
        {
        }
    
        public void OnProviderDisabled(string provider)
        {
        }
    
        public void OnProviderEnabled(string provider)
        {
        }
    
        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
        }
    }
