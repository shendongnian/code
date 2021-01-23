    public abstract class MyBaseClass
    {
        public virtual bool CanConvert(Type objectType)
        {
            return false;
        }
    }
    public abstract class MyClass<T,I> : MyBaseClass
        where T : MyClass<T,I>
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(MyClass<T, I>).IsAssignableFrom(objectType);
        }
    }
