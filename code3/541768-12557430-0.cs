    class Program
    {
        static void Main(string[] args)
        {
            var tr = new SpecificTransaction();
            Console.WriteLine(tr.MyMethod()); //shows 1
        }
    }
    public abstract class Transaction
    {
        public abstract int MyMethod();
    }
    public abstract class GeneralTransaction : Transaction
    {
        public override int MyMethod()
        {
            return 1;
        }
    }
    public class SpecificTransaction : GeneralTransaction
    {
    }
