    static void Main(string[] args)
    {
        StartProcessing();
        StatusReport();
        Console.ReadLine();
    }
    static ServiceClient Client = new ServiceClient();
    private static bool Completed = false;
    public static void StartProcessing()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(@"D:\t72CalculateReasonableWithdrawal_Input.xml");
        bool error = false;
        Client.ProcessingCompleted += Client_ProcessingCompleted;
        Client.ProcessingAsync(doc.OuterXml);
        Console.WriteLine("Processing...");
    }
    static void Client_ProcessingCompleted(object sender, ProcessingCompletedEventArgs e)
    {
        // processing is completed, retreive the return value of Processing operation
        Completed = true;
        Console.WriteLine(e.Result);
    }
    public static void StatusReport()
    {
        int i = 0;
        string temp;
        while (!Completed)
        {
            temp = Client.Status();
            Console.WriteLine("TotalTestScenarios;CurrentTestCase = {0}", temp);
            Thread.Sleep(500);
            i++;
        }
    }
