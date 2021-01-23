        [Activity(Label = "MonoAndroidApplication1", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var targetView = new OvalView(this);
            SetContentView(targetView);
        }
    }
    
    public class OvalView : View
    {
        public OvalView(Context context) : base(context) { }
    
        protected override void OnDraw(Canvas canvas)
        {
            RectF rect = new RectF(0,0, 300, 300);
            canvas.DrawOval(rect, new Paint() { Color = Color.CornflowerBlue });
        }
    }
