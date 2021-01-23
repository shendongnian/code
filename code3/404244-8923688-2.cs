    public class ClassB : ClassA
    {
        public new int? _shouldBeInteger
        {
            get { return (base._shouldBeInteger != null) ?
                         Convert.ToInt32(Convert.ToDouble(base._shouldBeInteger)) : 
                         new int?(); }
            set { base._shouldBeInteger = Convert.ToString(value); }
        }
    }
