    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            FooConverter.AddProperty("Time", typeof(DateTime));
            FooConverter.AddProperty("Age", typeof(int));
            using (var grid = new PropertyGrid { Dock = DockStyle.Fill, SelectedObject = new Foo() })
            using (var form = new Form { Controls = { grid } })
            {
                Application.Run(form);
            }
        }
    }
    class FooConverter : ExpandableObjectConverter
    {
        private static readonly List<Tuple<string, Type>> customProps = new List<Tuple<string, Type>>();
        public static void AddProperty(string name, Type type)
        {
            lock (customProps) customProps.Add(Tuple.Create(name, type));
        }
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, System.Attribute[] attributes)
        {
     	    var orig = base.GetProperties(context, value, attributes);
            lock(customProps)
            {
                if(customProps.Count == 0) return orig;
    
                PropertyDescriptor[] props = new PropertyDescriptor[orig.Count + customProps.Count];
                orig.CopyTo(props, 0);
                int i = orig.Count;
                foreach (var prop in customProps)
                {
                    props[i++] = new SimpleDescriptor(prop.Item1, prop.Item2);
                }
                return new PropertyDescriptorCollection(props);
            }
        }
        class SimpleDescriptor : PropertyDescriptor
        {
            private readonly Type type;
            public SimpleDescriptor(string name, Type type)
                : base(name, new Attribute[0])
            {
                this.type = type;
            }
            public override Type PropertyType { get { return type;} }
            public override bool SupportsChangeEvents { get { return false; } }
            public override void ResetValue(object component) { SetValue(component, null); }
            public override bool CanResetValue(object component) { return true; }
            public override bool ShouldSerializeValue(object component) { return GetValue(component) != null; }
            public override bool IsReadOnly { get { return false; } }
            public override Type ComponentType { get { return typeof(Foo); } }
            public override object GetValue(object component) { return ((Foo)component).GetExtraValue(Name); }
            public override void SetValue(object component, object value) { ((Foo)component).SetExtraValue(Name, value); }
            public override string Category { get { return "Extra values"; } }
        }
    }
    [TypeConverter(typeof(FooConverter))]
    public class Foo
    {
        Dictionary<string, object> extraValues;
        internal object GetExtraValue(string name)
        {
            object value;
            if (extraValues == null || !extraValues.TryGetValue(name, out value)) value = null;
            return value;
        }
        internal void SetExtraValue(string name, object value)
        {
            if (extraValues == null && value != null) extraValues = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
            if (value == null) extraValues.Remove(name);
            else extraValues[name] = value;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
