    public interface IInterface
    {}
    public class Banana
    {
    }
    class Program
    {
        static void Main( string[] args )
        {
            Banana banana = new Banana();
            IInterface b = (IInterface)banana;
        }
    }
