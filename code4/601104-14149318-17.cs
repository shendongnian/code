    static void CallRestFunc()
    {
         WebClient RestProxy = new WebClient();
         byte[] data = RestProxy.DownloadData(new Uri("http://localhost:30576/MathRest.svc/Rest/Add/7/2")); // As you see it is following the exact location of the project, invoking method / parameter and so on down the line.
    Stream stream = new MemoryStream(data);
    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(string));
    string result = obj.ReadObject(stream).ToString();
    Console.WriteLine(result);
    }
