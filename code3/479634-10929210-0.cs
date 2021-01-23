    eadonly object _object = new object();
    // 1st function calls this
    lock (_object)
    {
          queue.Add(msg);
    }
    
    // 2nd function calls this
    lock (_object)
    {
          using (StreamWriter outfile = new StreamWriter("path", true)
          {
                 foreach (Message msg in queue) // This is were I get the exception after a while)
                 {
                      outfile.WriteLine(JsonConvert.SerializeObject(msg)); 
                 }
    
                  queue = new List<Message>();
          }
    }
