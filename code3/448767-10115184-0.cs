    for (int counter = 0; counter < numberOfChunks; counter++)
    {
        int localCounter = counter;
        tasks[localCounter] = Task.Factory.StartNew(() =>
            {
                // counter is always = 5  why?   <---------------------------
                var t = ListToProcess[localCounter];                        
            });
    }
