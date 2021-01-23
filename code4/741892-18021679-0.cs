    public class Program
    {
        static void Main()
        {
            var m = new Helper();
            m.Add(new ConcreteClass());
        }
        class Helper
        {
            List<ConcreteClass> data=new List<ConcreteClass>();
            public void Add<T1>(T1 thing) where T1 : ConcreteClass
            {
                this.data.Add(thing);
            }
        }
        class AbstractClass<T> { }
        class OtherClass { }
        class ConcreteClass : AbstractClass<OtherClass> { }
    }
