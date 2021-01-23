            ConcurrentDictionary<int, BlockingCollection<string>> mailBoxes = new ConcurrentDictionary<int, BlockingCollection<string>>();
            int maxBoxes = 5;
            CancellationTokenSource cancelationTokenSource = new CancellationTokenSource();
            CancellationToken cancelationToken = cancelationTokenSource.Token;
            Random rnd = new Random();
            // Producer
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    int index = rnd.Next(0, maxBoxes);
                    // put the letter in the mailbox 'index'
                    var box = mailBoxes.GetOrAdd(index, new BlockingCollection<string>());
                    box.Add("some message " + index, cancelationToken);
                    Console.WriteLine("Produced a letter to put in box " + index);
                    // Wait simulating a heavy production item.
                    Thread.Sleep(1000);
                }
            });
            // Consumer 1
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    int index = rnd.Next(0, maxBoxes);
                    // get the letter in the mailbox 'index'
                    var box = mailBoxes.GetOrAdd(index, new BlockingCollection<string>());
                    var message = box.Take(cancelationToken);
                    Console.WriteLine("Consumed 1: " + message);
                    // consume a item cost less than produce it:
                    Thread.Sleep(50);
                }
            });
            // Consumer 2
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    int index = rnd.Next(0, maxBoxes);
                    // get the letter in the mailbox 'index'
                    var box = mailBoxes.GetOrAdd(index, new BlockingCollection<string>());
                    var message = box.Take(cancelationToken);
                    Console.WriteLine("Consumed 2: " + message);
                    // consume a item cost less than produce it:
                    Thread.Sleep(50);
                }
            });
            Console.ReadLine();
            cancelationTokenSource.Cancel();
