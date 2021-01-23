    public void WriteFiles()
    {
        using (BlockingCollection<string> bc = new BlockingCollection<string>(10))
        {
            // play with 10 if you have several small files then a big file
            // write can get ahead of read if not enough are queued
            // Spin up a Task to populate the BlockingCollection
            TextWriter tw = new StreamWriter(@"c:\temp\alltext.text", true);
            // clearly you want to write to a different phyical disk 
            // ideally write to solid state even if you move the files to regular disk when done
            using (Task t1 = Task.Factory.StartNew(() =>
            {
                string dir = @"c:\temp\";
                string fileText;      
                int minSize = 100000; // play with this
                StringBuilder sb = new StringBuilder(minSize);
                string[] fileAry = Directory.GetFiles(dir, @"*.txt");
                foreach (string fi in fileAry)
                {
                    Debug.WriteLine("Add " + fi);
                    fileText = File.ReadAllText(fi);
                    //bc.Add(fi);  for testing just add filepath
                    if (sb.Length == 0 && fileText.Length > minSize)
                    {
                        bc.Add(fileText);
                    }
                    else
                    {
                        sb.Append(fileText);
                        if (sb.Length > minSize) bc.Add(sb.ToString());
                        sb.Clear();
                    }
                }
                if (sb.Length > 0) bc.Add(sb.ToString());
                sb.Clear();
                bc.CompleteAdding();
            }))
            {
    
                // Spin up a Task to consume the BlockingCollection
                using (Task t2 = Task.Factory.StartNew(() =>
                {
                    string text;
                    try
                    {
                        while (true)
                        {
                            text = bc.Take();
                            Debug.WriteLine("Take " + text);
                            tw.WriteLine(text);                  
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        // An InvalidOperationException means that Take() was called on a completed collection
                        Debug.WriteLine("That's All!");
                        tw.Close();
                        tw.Dispose();
                    }
                }))
    
                    Task.WaitAll(t1, t2);
            }
        }
    }
