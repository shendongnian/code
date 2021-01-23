    var ser = new DataContractJsonSerializer(typeof(Sample[]));
    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(JSON))) {
        Sample[] s = (Sample[])ser.ReadObject(ms);
    }
    [DataContract]
    public class Sample {
        [DataMember]
        public int AdvertId { get; set; }
        [DataMember(Name = "Price Original")]
        public string PriceOriginal { get; set; }
        [DataMember]
        public bool Sold { get; set; }
    }
