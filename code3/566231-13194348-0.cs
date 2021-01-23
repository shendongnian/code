    public interface IFoo
    {
        ICollection<IBar> Bars { get; set; }
    }
    public interface IBar
    {
        
    }
    public class Foo : IFoo
    {
        public ICollection<IBar> Bars { get; set; }
    }
    public class Bar : IBar
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            IFoo myFoo = new Foo();
            List<IBar> lstBar = new List<IBar>();
            lstBar.Add(new Bar());
            myFoo.Bars = lstBar;
        }
    }
