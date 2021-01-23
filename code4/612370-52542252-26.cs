        public async static void DoSomeWork()
        {
            var result = await Task.Run(() =>
            {
                // [RUNS ON WORKER THREAD]
                // IS bubbling up
                throw new Exception();
                Thread.Sleep(2000);
                
                return "Hello";
            });
            // every thing below is a callback 
            // (including the calling methods)
            Console.WriteLine("Completed");
        }
