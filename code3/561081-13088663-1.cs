    [DataContract]
    class thinger
    {
        [DataMember]
        public string name;
    }
    string snip = @"{""name"": ""\uc9c0\uc9c0\ud5a5""}";
    Byte[] bytes = Encoding.Unicode.GetBytes(snip);
    MemoryStream jsonstream = new MemoryStream(bytes);
    jsonstream.Write(bytes, 0, bytes.Length);
    jsonstream.Seek(0, SeekOrigin.Begin);
    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(thinger));
    thinger output = (thinger)ser.ReadObject(jsonstream);
    //output.name = 지지향
