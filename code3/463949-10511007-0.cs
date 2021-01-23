    private object _lockObject = new object(); // shared by all threads.
    public void WriteMsg(string Msg)
    {
         lock (_lockObject)
         {
            using (StreamWriter sw = new StreamWriter(sPathName, true))
            {
                sw.WriteLine(Msg);
            }
         }
    }
