    try
    {
        watcher.EnableRaisingEvents = false;
        try
        {
          XmlDocument xdoc = new XmlDocument();
          xdoc.Load(FileName);
        }
        catch (XmlException xe)
        {
          System.Threading.Thread.Sleep(1000);  //added this line
          using (StreamWriter w = File.AppendText(FileName))
          {
            Console.WriteLine(xe);
            w.WriteLine("</test>");
            w.WriteLine("</testwrapper>");
          }
        }
    }
