    using System;
    using System.Globalization;
    using Android.App;
    using Android.Content;
    using Android.Runtime;
    using Android.Util;
    using Android.Widget;
    using Android.OS;
    
    namespace AndroidApplication1
    {
        [Activity(Label = "AndroidApplication1", MainLauncher = true, Icon = "@drawable/icon")]
        public class Activity1 : Activity
        {
            int count = 1;
    
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
    
                // Get our button from the layout resource,
                // and attach an event to it
                Button button = FindViewById<Button>(Resource.Id.MyButton);
    
                button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
    
                var seekbar = new TTSeekBar(this);
    
                var ll = FindViewById<LinearLayout>(Resource.Id.LinearLayout);
    
                ll.AddView(seekbar);
            }
        }
    
        public class TTSeekBar : SeekBar
        {
            protected TTSeekBar(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
            {
            }
    
            public TTSeekBar(Context context) : base(context)
            {
            }
    
            public TTSeekBar(Context context, IAttributeSet attrs) : base(context, attrs)
            {
            }
    
            public TTSeekBar(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
            {
            }
    
            private int _min = 0;
            public int Min { get { return _min; } set { _min = value; } }
    
            public override int Progress
            {
                get
                {
                    return base.Progress + _min;
                }
                set
                {
                    base.Progress = value;
                }
            }
    
            public override int Max
            {
                get
                {
                    return base.Max + _min;
                }
                set
                {
                    base.Max = value + _min;
                }
            }
    
            public object GetInputData()
            {
                return (Progress + _min).ToString(CultureInfo.InvariantCulture);
            }
        }
    }
