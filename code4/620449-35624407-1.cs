    [DataContract]
    public class Item
    {
        [DataMember(Name = "kpiId")]
        public string KPIId { get; set; }
        [DataMember(Name = "value")]
        public string Value { get; set; }
        [DataMember(Name = "unit")]
        public string Unit{ get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "category")]
        public string Category { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "source")]
        public string Source { get; set; }
        [DataMember(Name = "messages")]
        public SysMessage[] Messages { get; set; }
        public object getDataMemberByName(string name)
        {
             return (typeof(Item).GetProperties().FirstOrDefault(p => p.GetCustomAttributes(typeof(DataMemberAttribute), false)
                                  .OfType<DataMemberAttribute>()
                                  .Any(x => x.Name == name))).GetValue(this);
        }
    }
