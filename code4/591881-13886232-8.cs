    using System;
    
    namespace WpfApplication
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
        public sealed class NameValueAttribute : Attribute
        {
            public string Name { get; set; }
            public object Value { get; set; }
        }
    }
