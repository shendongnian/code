    public abstract class BaseClass
    {
        protected class Arg<T>
        {
            public T Value { get; set; }
            public Arg(T value) { this.Value = value; }
        }
        public static BaseClass CreateInstance(DataTable dataTable)
        {
            return new Child1(new Arg<DataTable>(dataTable));
        }
        public static BaseClass CreateInstance(DataSet dataSet)
        {
            return new Child2(new Arg<DataSet>(dataSet));
        }
    }
    public class Child1 : BaseClass
    {
        public Child1(Arg<DataTable> arg) : this(arg.Value) { }
        private Child1(DataTable dataTable)
        {
        }
    }
    public class Child2 : BaseClass
    {
        public Child2(Arg<DataSet> arg) : this(arg.Value) { }
        public Child2(DataSet dataSet)
        {
        }
    }
