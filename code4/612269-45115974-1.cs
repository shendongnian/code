    // Starts counting to a large number and then immediately displays message "I'm counting...". 
    // Then it waits for task to finish and displays "finished, press any key".
    static void asyncTest ()
    {
        Console.WriteLine("Started asyncTest()");
        Task<long> task = asyncTest_count();
        Console.WriteLine("Started counting, please wait...");
        task.Wait(); // if you comment this line you will see that message "Finished counting" will be displayed before we actually finished counting.
        //Console.WriteLine("Finished counting to " + task.Result.ToString()); // using task.Result seems to also call task.Wait().
        Console.WriteLine("Finished counting.");
        Console.WriteLine("Press any key to exit program.");
        Console.ReadLine();
    }
    static async Task<long> asyncTest_count()
    {
        long k = 0;
        Console.WriteLine("Started asyncTest_count()");
        await Task.Run(() =>
        {
            long countTo = 100000000;
            int prevPercentDone = -1;
            for (long i = 0; i <= countTo; i++)
            {
                int percentDone = (int)(100 * (i / (double)countTo));
                if (percentDone != prevPercentDone)
                {
                    prevPercentDone = percentDone;
                    Console.Write(percentDone.ToString() + "% ");
                }
                k = i;
            }
        });
        Console.WriteLine("");
        Console.WriteLine("Finished asyncTest_count()");
        return k;
    }
