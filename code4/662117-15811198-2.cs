    try
    {
        watcher.EnableRaisingEvents = false;
        //Edit2: Remove the watcher event
        watcher.Changed -= new FileSystemEventHandler(convert);
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
    /*
       Here all xslt transform code
    */
        //Edit2: Add again the watcher event
        watcher.Changed += new FileSystemEventHandler(convert);
    }
    catch (Exception e)
    {
       Console.WriteLine("The process failed: {0}", e.ToString());
    }
