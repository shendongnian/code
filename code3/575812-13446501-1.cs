    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class FormatAttribute : Attribute
    {
        public FormatAttribute()
        {
            Trim = true;
        }
        public bool Trim { get; set; }
    }
