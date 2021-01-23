    public sealed class MyActivity : NativeActivity
    {
        public Activity Body { get; set; }
     
        protected override void Execute(NativeActivityContext context)
        {
            context.ScheduleActivity(Body);
        }
    }
