    var lista = new List<Type>();
    lista.Add(typeof(Google.GData.YouTube.YouTubeEntry));
    
    using (FileStream writer = new FileStream("c:/temp/file.xml", FileMode.Create, FileAccess.Write))
    {
        DataContractSerializer ser = new DataContractSerializer(videoContainer.GetType(), lista);
        ser.WriteObject(writer, videoContainer);
    }
