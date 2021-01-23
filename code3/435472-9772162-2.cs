    foreach (BasicLog basicLog in emailAttach)
    {
        using(System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\sorted.txt", true))
        {
            file.WriteLine(basicLog.LastName + " - " + basicLog.InOrOut + " - " + basicLog.EventTime + "\n");
        }
    }
