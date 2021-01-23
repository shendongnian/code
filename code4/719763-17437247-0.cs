    using System.Text;
    using Android.App;
    using Android.Hardware;
    using Android.Widget;
    using Android.OS;
    
    namespace AccelerometerShiz
    {
        [Activity(Label = "AccelerometerShiz", MainLauncher = true, Icon = "@drawable/icon")]
        public class Activity1 : Activity, ISensorEventListener
        {
            private SensorManager _sensorManager; 
            private TextView _sensorTextView; 
            private static readonly object SyncLock = new object();
    
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
                _sensorManager = (SensorManager)GetSystemService(SensorService);
                _sensorTextView = FindViewById<TextView>(Resource.Id.accelerometer_text);
            }
    
            protected override void OnResume()
            {
                base.OnResume();
                _sensorManager.RegisterListener(this, _sensorManager.GetDefaultSensor(SensorType.Accelerometer), SensorDelay.Ui);
            }
    
            protected override void OnPause()
            {
                base.OnPause();
                _sensorManager.UnregisterListener(this);
            }
    
            public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
            {
                // We don't want to do anything here.
            }
    
            public void OnSensorChanged(SensorEvent e)
            {
                lock (SyncLock)
                {
                    var text = new StringBuilder("x = ")
                        .Append(e.Values[0])
                        .Append(", y=")
                        .Append(e.Values[1])
                        .Append(", z=")
                        .Append(e.Values[2]);
                    _sensorTextView.Text = text.ToString();
                }
            }
        }
    }
