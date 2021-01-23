        delegate void T2(byte[] array,string text, int num);
        static void Main(string[] args)
        {
            T2 hello = new T2(Work);
            while (true)
            {
                IAsyncResult result = hello.BeginInvoke(null, null);
                //OTHER WORK TO DO
                hello.EndInvoke(result);
            }
        }
        static void Work(byte[] array, string text, int num)
        {
            // WORK TO DO
        }
