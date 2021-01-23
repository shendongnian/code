    System.IO.StreamWriter file;
    foreach (BasicLog basicLog in emailAttach)
    {
        file = new System.IO.StreamWriter(@"C:\\sorted.txt", true);
        file.WriteLine(basicLog.LastName + " - " + basicLog.InOrOut + " - " + basicLog.EventTime + "\n");
    }
