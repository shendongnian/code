    //**Server**
    Task.Factory.StartNew(() =>
    {
        var reader = new StreamReader(tcpClient.GetStream());
        var writer = new StreamReader(tcpClient.GetStream());
        while (true)
        {
            var myobj = JsonConvert.DeserializeObject<MyCommunicationData>(reader.ReadLine());
            //do work with obj 
            //write response to client
            writer.WriteLine(JsonConvert.SerializeObject(commData));
        }
    }, 
    TaskCreationOptions.LongRunning);
