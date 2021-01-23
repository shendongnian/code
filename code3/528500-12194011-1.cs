    public class CheekyDisplayNameAttribute : DisplayNameAttribute
    {
        public CheekyDisplayNameAttribute(string resourceId)
            : base(resourceId)
        { }
        private static string GetMessageFromResource(string resourceId)
        {
            return resourceId + Interlocked.Increment(ref counter);
        }
        public override string DisplayName
        {
            get { return GetMessageFromResource(base.DisplayName); }
        }
        private static int counter;
    }
