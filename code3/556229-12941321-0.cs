            int count = 0;
            new Timer(_ => Console.WriteLine(count), 0, 0, 500);
            while (true)
            {
                Interlocked.Increment(ref count);
                Task.Factory.StartNew(() =>
                {
                    dynamic dyn2 = new ExpandoObject();
                    dyn2.text = Get500kOfText() + Get500kOfText() + DateTime.Now.ToString() +
                      DateTime.Now.Millisecond.ToString();
                    Interlocked.Decrement(ref count);
                });
            }
