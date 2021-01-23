        delegate void T2();
        static void Main(string[] args)
        {
            T2 Thread = new T2(Work);
            while (true)
            {
                IAsyncResult result = Thread.BeginInvoke(null, null);
                //OTHER WORK TO DO
                Thread.EndInvoke(result);
            }
        }
        static void Work()
        {
           //WORK TO DO
        }
