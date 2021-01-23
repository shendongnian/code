    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\sorted.txt", true))   
    {
       foreach (BasicLog basicLog in emailAttach)
       {     
          file.WriteLine(basicLog.LastName + " - " + basicLog.InOrOut + " - " + basicLog.EventTime + "\n");
       }
    }
