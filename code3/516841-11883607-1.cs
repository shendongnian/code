            static void Main(string[] args)
        {
            string  filename = @"c:\vs\temp\test.txt";
            int maxEntries = 2;
            var c = new BlockingCollection<String>(maxEntries);
            
            var taskAdding = Task.Factory.StartNew(delegate
            {
                var lines = File.ReadLines(filename);
                foreach (var line in lines)
                {
                    c.Add(line);    // when there are maxEntries items
                                    // in the collection, this line 
                                    // and thread will block until 
                                    // the processing thread removes 
                                    // an item
                }
                c.CompleteAdding(); // this tells the collection there's
                                    // nothing more to be added, so the 
                                    // enumerator in the other thread can 
                                    // end
            });
            while (c.Count < 1)
            {
                // this is here simply to give the adding thread time to
                // spin up in this much simplified sample
            }
            Parallel.ForEach(c.GetConsumingEnumerable(), i =>
               {
                   // NOTE: GetConsumingEnumerable() removes items from the 
                   //   collection as it enumerates over it, this frees up
                   //   the space in the collection for the other thread
                   //   to write more lines from the file
                   Console.WriteLine(i);  
               });
            Console.ReadLine();
        }
