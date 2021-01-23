    public class Activity1 : Activity
    {
        ...
        private CustomCalendar _calendar;
        public override void OnCreate()
        {
            SetContentView(Resource.Layout.Calendar);
            _calendar = FindViewById<CustomCalendar>(Resource.Id.Calendar1);
            LayoutInflater li = (LayoutInflater)GetSystemService(Context.LayoutInflaterService);
            
            View v = li.Inflate(Resource.Layout.Calendar, null);
            int widthMeasureSpec = View.MeasureSpec.MakeMeasureSpec(Resources.DisplayMetrics.WidthPixels, MeasureSpecMode.Exactly);
            int heightMeasureSpec = View.MeasureSpec.MakeMeasureSpec(Resources.DisplayMetrics.HeightPixels, MeasureSpecMode.Exactly);
            
            v.Measure(widthMeasureSpec, heightMeasureSpec);
            ...
        }
    }
