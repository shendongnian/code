    public class BaseClass : DependencyObject
    {
        public static readonly DependencyProperty Property1Property = DependencyProperty.Register(
            "Property1",
            typeof(string),
            typeof(BaseClass),
            new PropertyMetadata(null));
        public string Property1
        {
            get { return (string)GetValue(Property1Property); }
            set { SetValue(Property1Property, value); }
        }
        public static readonly DependencyProperty Property2Property = DependencyProperty.Register(
            "Property2",
            typeof(int[]),
            typeof(BaseClass),
            new PropertyMetadata(null));
        public int[] Property2
        {
            get { return (int[])GetValue(Property2Property); }
            set { SetValue(Property2Property, value); }
        }
        public static readonly DependencyProperty Property3Property = DependencyProperty.Register(
            "Property3",
            typeof(object),
            typeof(BaseClass),
            new PropertyMetadata(null));
        public object Property3
        {
            get { return GetValue(Property3Property); }
            set { SetValue(Property3Property, value); }
        }
    }
    public class ModifiedClass : BaseClass
    {
        public static readonly new DependencyProperty Property1Property = DependencyProperty.Register(
            "Property1",
            typeof(string),
            typeof(ModifiedClass),
            new PropertyMetadata(null));
        public new string Property1
        {
            get { return (string)GetValue(Property1Property); }
            set { SetValue(Property1Property, value); }
        }
        public static readonly new DependencyProperty Property2Property = DependencyProperty.Register(
            "Property2",
            typeof(long[]),
            typeof(ModifiedClass),
            new PropertyMetadata(null));
        public new long[] Property2
        {
            get { return (long[])GetValue(Property2Property); }
            set { SetValue(Property2Property, value); }
        }
        public static readonly new DependencyProperty Property3Property = DependencyProperty.Register(
            "Property3",
            typeof(string),
            typeof(ModifiedClass),
            new PropertyMetadata(null));
        public new string Property3
        {
            get { return (string)GetValue(Property3Property); }
            set { SetValue(Property3Property, value); }
        }
    }
