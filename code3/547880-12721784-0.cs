    //**Server**
    Task.Factory.StartNew(() =>
    {
        var reader = new StreamReader(tcpClient);
        var write = new StreamReader(tcpClient);
        while (true)
        {
            var myobj = JsonConvert.DeserializeObject<MyCommunicationData>(reader.ReadLine());
            //do work with obj 
            //write response to client
            writer.WriteLine(JsonConvert.SerializeObject(commData));
        }
    }, 
    TaskCreationOptions.LongRunning);
