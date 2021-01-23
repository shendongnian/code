        private void RunTasks()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<Task> tasks = new List<Task>();
            foreach (KeyValuePair<string,string> kvp in dict)
            {
                Console.WriteLine("Executing task " + kvp.Key + " ...");
                Task t = new Task(() => MyMethod(kvp.Key, kvp.Value));
                tasks.Add(t);
                t.Start();
                t.ContinueWith(task => Console.WriteLine(kvp.Key + " completed"));
            }
            Console.WriteLine("Waiting tasks to complete...");
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("All tasks completed...");
        }
        private void MyMethod(string arg1, string arg2)
        {
        }
