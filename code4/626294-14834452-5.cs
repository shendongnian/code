    public class Service1 : IService1
    {
        public DateTime GetData()
        {
            System.Threading.Thread.Sleep(5000);
            return DateTime.Now;
        }
    }
