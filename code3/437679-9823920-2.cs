    public abstract class IDetail{}
    public class ConcreteDetail : IDetail{ }
    // My interface and class examples:
    public interface IHeader<T> where T: IDetail
    {
         IList<T> Details { get; set; }
    }
    public class ConcreteHeader : IHeader<ConcreteDetail>
    {
        public IList<ConcreteDetail> Details { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            object obj = new ConcreteHeader() 
                { Details = new List<ConcreteDetail>() };
            // works as expected...
            var casted = obj as ConcreteHeader;
            // fails if IDetail is interface, passes if abstract class
            var details = ((IHeader<ConcreteDetail>)obj).Details; 
            Console.ReadKey();
       }
    }
