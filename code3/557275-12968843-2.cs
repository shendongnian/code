    ManualResetEventSlim manualEvent = new ManualResetEventSlim (false);
    
    for (int i = 0; i < 20000; i++)
    {
        Thread t = new Thread(() => TestOrchestration(i));
        t.Start();
    }
    manualEvent.Set();
    
    void TestOrchestration(int number)
    {
        manualEvent.Wait();
        Document doc = new Document(string.Format("Test {0}", number));
        doc = DoOrchestration(doc);
        if (doc.ToString().Substring(0,35) != strExpectedResult)
        {
            System.Console.WriteLine("Error: {0}", doc.ToString();
        }
    }
