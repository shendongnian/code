            public static IEnumerable<char> SplitItOut(IEnumerable<string> words)
            {
                var source = new ConcurrentBag<string>(words);
                var chars = new BlockingCollection<char>();
    
                var tasks = new[]
                                   {
                                       Task.Factory.StartNew(() => CharProducer(source, chars)),
                                       Task.Factory.StartNew(() => CharProducer(source, chars)),
                                       //add more, tweak away, or use a factory to create more tasks.
                                       //measure before you simply add more!
                                   };
    
                Task.Factory.ContinueWhenAll(tasks, t => chars.CompleteAdding());
    
                return chars.GetConsumingEnumerable();
            }
