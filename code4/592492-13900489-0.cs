    static void Main(string[] args)
    {
        string json = "{\"kotanya\":[\"bekasi\",\"bekasi barat\",\"bekasi selatan\",\"bekasi timur\",\"bekasi utara\",\"serang bekasi\"]}";
        var s = new DataContractJsonSerializer(typeof(kota));
        using (var m = new MemoryStream(Encoding.ASCII.GetBytes(json)))
        {
            var r = s.ReadObject(m);
        }
    }
    [DataContract]
    public class kota
    {
        [DataMember]
        public string[] kotanya { get; set; }
    }
