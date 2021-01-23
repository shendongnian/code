    private static SemaphoreSlim SlowStuffSemaphore = new SemaphoreSlim(1, 1);
    private static async void CallSlowStuff () {
        await SlowStuffSemaphore.WaitAsync();
        try {
            await DoSlowStuff();
            Console.WriteLine("Done!");
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }
        finally {
            SlowStuffSemaphore.Release();
        }
    }
