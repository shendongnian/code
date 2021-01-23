    public class Program
    {
        static void Main()
        {
            var m = new Helper();
            m.Add(new ConcreteClass());
            m.Process();
        }
        class Helper
        {
            List<IAbstractClass<OtherClassBase>> data = new List<IAbstractClass<OtherClassBase>>();
            public void Add(IAbstractClass<OtherClassBase> thing)
            {
                this.data.Add(thing);
            }
            public void Process()
            {
                foreach(var c in data.Where(x => x.ShouldBeProcessed()))
                {
                    var b = c.Invoke();
                    Console.WriteLine(b.Question);
                    var castData = b as OtherClass;
                    if (castData != null)
                        Console.WriteLine(castData.Answer);
                }
            }
        }
        public interface IAbstractClass<out T>
        {
            bool ShouldBeProcessed();
            T Invoke();
        }
        abstract class AbstractClass<T> : IAbstractClass<T>
        {
            public bool ShouldBeProcessed()
            {
                return true;
            }
            public abstract T Invoke();
        }
        class ConcreteClass : AbstractClass<OtherClass>
        {
            public override OtherClass Invoke()
            {
                return new OtherClass();
            }
        }
        class OtherClassBase
        {
            public string Question { get { return "What is the answer to life, universe, and everything?"; } }
        }
        class OtherClass : OtherClassBase
        {
            public int Answer { get { return 42; } }
        }
    }
