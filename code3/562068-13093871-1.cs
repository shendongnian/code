    private void Request()
    {
        //Makes Request
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost/Test.php");
        request.ContentType = "application/json; charset=utf-8";
        request.Accept = "application/json, text/javascript, */*";
        request.Method = "POST";
        using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
        {
            writer.Write("{id : 'test'}");
        }
    
        //Gets response
        WebResponse response = request.GetResponse();
        Stream stream = response.GetResponseStream();
        string json = "";
        using (StreamReader reader = new StreamReader(stream))
        {
            //Save it to text file
            using (TextWriter savetofile = new StreamWriter("C:/text.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    savetofile.WriteLine(line);
                    json += line;
                }
            }
        }
    
        //Decodes the JSON
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(MyCustomDict));
        MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
        MyCustomDict dict = (MyCustomDict)dcjs.ReadObject(ms);
    
        //Do something with values.
        foreach(var key in dict.dict.Keys)
        {
            Console.WriteLine( key);
            foreach(var value in dict.dict[key])
            {
                Console.WriteLine("\t" + value);
            }
        }
    
    }
    [Serializable]
    public class MyCustomDict : ISerializable
    {
        public Dictionary<string, object[]> dict;
        public MyCustomDict()
        {
            dict = new Dictionary<string, object[]>();
        }
        protected MyCustomDict(SerializationInfo info, StreamingContext context)
        {
            dict = new Dictionary<string, object[]>();
            foreach (var entry in info)
            {
                object[] array = entry.Value as object[];
                dict.Add(entry.Name, array);
            }
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            foreach (string key in dict.Keys)
            {
                info.AddValue(key, dict[key]);
            }
        }
    }
