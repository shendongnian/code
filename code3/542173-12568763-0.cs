        delegate void T2();
        static void Main(string[] args)
        {
            T2 Thread = new T2(Work);
            while (true)
            {
                IAsyncResult result = hello.BeginInvoke(null, null);
                //OTHER WORK TO DO
                hello.EndInvoke(result);
            }
        }
        static void Work()
        {
           //WORK TO DO
        }
