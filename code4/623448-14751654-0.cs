        public static Task<long> AsyncMethod()
        {
            var task = new Task<long>(() =>
            {
                long myVal = 1;
                for (long l = 0; l < 100000; l++)
                {
                    myVal++;
                    Console.WriteLine("l = {0}", l);
                }
                return myVal;
            });
            task.Start();
            return task;
        }
