            var tasks = new List<Task>();
            //start tasks
            foreach (var file in list)
            {
                var localFile = file; //local variable on advice of resharper
                tasks.Add(Task<string>.Factory.StartNew(() => GetVersion(localFile)));
            }
            //wait for them to complete
            Task.WaitAll(tasks.ToArray());
            //read the results
            IEnumerable<string> result = tasks.OfType<Task<string>>().Select(e => e.Result);
            //print em out for test
            foreach (var str in result)
            {
                Console.WriteLine(str);
            }
