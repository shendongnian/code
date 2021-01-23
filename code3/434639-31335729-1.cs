    private void TestCancellationHttpClient()
    {
        try
        {
            var sonnetFetcher = new HttpSonnetFetcher();
            var cancellationTokenSource = new CancellationTokenSource();
            var sonnetTask = Task.Run(() => sonnetFetcher.Fetch(cancellationTokenSource.Token));
            cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(10));
            // meanwhile do something else, checking regularly if the task finished, or if you have nothing to do, just Task.Wait():
            while (!sonnetTask.Wait(TimeSpan.FromSeconds(0.25)))
            {
                Console.Write('.');
            }
            // if still here: the sonnet is fetched. return value is in sonnetTask.Result
            Console.WriteLine("A nice sonnet by William Shakespeare:");
            foreach (var line in sonnetTask.Result)
            {
                Console.WriteLine(line);
            }
        }
        catch (OperationCanceledException exc)
        {
            Console.WriteLine("Canceled " + exc.Message);
        }
        catch (AggregateException exc)
        {
            Console.WriteLine("Task reports exceptions");
            var x = exc.Flatten();
            foreach (var innerException in x.InnerExceptions)
            {
                Console.WriteLine(innerException.Message);
            }
        }
        catch (Exception exc)
        {
            Console.WriteLine("Exception: " + exc.Message);
        }
    }
