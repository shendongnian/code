    //Receiver
    StreamReader reader = new StreamReader(Nw);
    while (true)
    {
        List<string[]> result = new JavaScriptSerializer()
                    .Deserialize<List<string[]>>(reader.ReadLine());
        //do some work with "result"
                
    }
    //Sender
    StreamWriter writer = new StreamWriter(Nw);
    while (true)
    {
        //form your "list" and send
        writer.WriteLine(new JavaScriptSerializer().Serialize(list));
        writer.Flush();
    }
