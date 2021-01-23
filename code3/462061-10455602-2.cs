    public delegate void FooDelegate<T>(T value) where T : IFooValue;
    
    public class FooContainer
    {
        public event FooDelegate<IFooValue> FooEvent;
    
        protected void OnFooEvent(IFooValue value)
        {
            if (this.FooEvent != null)
                this.FooEvent(value);
        }
    }
    
    public interface IFooValue
    {
        string Name { get; set; }// just an example member
    }
