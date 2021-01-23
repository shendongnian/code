            List<byte[]> inputArray = new List<byte[]>();
            int[] outputArray = new int[inputArray.Count];
            var waitHandle = new ManualResetEvent(false);
            int counter = 0;
            Parallel.For(0, inputArray.Count, index =>
                {
                    // Pass index to for loop, do long running operation 
                    // on input items
                    // writing to only a single output item
                    outputArray[index] = DoOperation(inputArray[index]);
                    if(Interlocked.Increment(ref counter) == inputArray.Count -1)
                    {
                        waitHandle.Set();
                    }
                });
            waitHandler.WaitOne();
            // Optional conversion back to list if you wanted this
            var outputList = outputArray.ToList();
