    public class Client
    {
        static Object ibj = new Object();
        public void Test(string item)
        {
            lock (ibj)
            {
                for (int i = 0; i < 200000; i++)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
