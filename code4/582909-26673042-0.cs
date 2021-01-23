    public class ValueStore
    {
        public Object GetValue()
        {
            return 1;
        }
        public void SetValue(Object obj)
        {
        }
    }
    public class ImplicitCaptureClosure
    {
        public void Captured()
        {
            var x = new object();
            ValueStore store = new ValueStore();
            Action action = () => store.SetValue(x);
            Func<Object> f = () => store.GetValue();    //Implicitly capture closure: x
        }
    }
