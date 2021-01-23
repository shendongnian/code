    class Program
    {
        static void Main(string[] args)
        {
            MyCodeService service = new MyCodeService();
            IMyCodeService serviceContract = (IMyCodeService)service;
            IMyCode codeContract = (IMyCode)service;
            service.GetResult();
            serviceContract.GetResult();
            codeContract.GetResult();
            Console.ReadKey();
        }
    }
    public interface IMyCode
    {
        void GetResult();
    }
    public interface IMyCodeService : IMyCode
    {
        void GetResult();
    }
    public class MyCodeService : IMyCodeService
    {
        public void GetResult()
        {
            Console.Write("I am here");
        }
    }
