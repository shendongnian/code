    try
    {
        Console.WriteLine(GetTradesOnline(0));
        string data = File.ReadAllText(@"C:\mydata.txt");
        Console.WriteLine(SubmitData(data));
        Console.WriteLine(SubmitForm("The Big Project", "Progress", "John Smith", "almost done"));
    }
    catch (WebException ex)
    {
        string msg;
        if (ex.Response != null)
        {
            // read response HTTP body
            using (var sr = new StreamReader(ex.Response.GetResponseStream())) msg = sr.ReadToEnd();
        }
        else
        {
            msg = ex.Message;
        }
        Log(msg);
        throw; // re-throw without changing the stack trace
    }
