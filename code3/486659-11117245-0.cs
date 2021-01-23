            List<byte[]> inputArray = new List<byte[]>();
            int[] outputArray = new int[inputArray.Count];
            Parallel.For(0, inputArray.Count, index =>
                {
                    // Pass index to for loop, do long running operation 
                    // on input items
                    // writing to only a single output item
                    outputArray[index] = DoOperation(inputArray[index]);
                });
            // Optional conversion back to list if you wanted this
            var outputList = outputArray.ToList();
