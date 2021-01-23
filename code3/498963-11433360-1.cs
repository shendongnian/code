        public void DoMultiOperations(Foo param, Action<IEnumerable<Bar>> callback)
        {
            var allResults = new ConcurrentQueue<Bar>();
            List<Task> tasks = new List<Task>(); 
            foreach(var item in data) 
            {
              tasks.Add(Task.Factory.StartNew(() => { 
                  var enumerable = processor.Provide(param);
                  foreach (var bar in enumerable)
                      allResults.Enqueue(bar);
                }); 
            }
              
            Task.WaitAll(tasks.ToArray());
            callback(allResults);
        }
