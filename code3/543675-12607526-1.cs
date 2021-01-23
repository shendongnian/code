    [DataContract(Namespace = "")]
    public class AccountData
    {
        [DataMember(Name = "ACCOUNTTYPEID")]
        public int Id { get; set; }
    }
    [DataContract(Name = "ROW", Namespace = "")]
    public class Row
    {
        [DataMember(Name = "AccountData")]
        public AccountData Data { get; set; }
    }
    [CollectionDataContract(Name="ROWSET", Namespace = "")]
    public class RowSet
        : List<Row>
    {
    }
