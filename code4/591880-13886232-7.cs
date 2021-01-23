    using System;
    
    namespace WpfApplication
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        public sealed class EditableAttribute : Attribute
        {
            public bool AllowEdit { get; set; }
        }
    }
