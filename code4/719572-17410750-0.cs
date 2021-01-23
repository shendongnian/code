    [DataContract(Name="rptaOk")]
    public class RptaOk
    {
        [DataMember(Name="idTercero")]
        public string IdTercero { get; set; }
    }
    
    [CollectionDataContract(Name="rptaOkList")]
    public class RptaOkList : List<RptaOk>{}
    
    var stream = new StreamReader(yourJsonObjectInStreamFormat);
    var serializer = new DataContractSerializer(typeof(RptaOkList));
    var result = (RptOkList) serializer.ReadObject(stream);
