        public static void Test()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                Test2(new object[] { 12345, "test" });
            });
        }
        private static void Test2(object data)
        {
            // Write to log that we got into the method - does not
            object[] args = data as object[];
            int num = Convert.ToInt32(args[0]);
            string name = (string)args[1];
            // call web service method here....
        }
