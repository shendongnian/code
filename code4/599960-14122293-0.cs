    [Serializable]
    [XmlRoot(ElementName = "SolrSearchEntity", Namespace = "")]
    [DataContract(Name = "SolrSearchEntity", Namespace = "")]
    public class SolrSearchEntity
    {
        [XmlElement(ElementName = "Id")]
        [DataMember(Name = "Id", IsRequired = true)]
        [SolrUniqueKey("id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "Name")]
        [DataMember(Name = "Name", IsRequired = true)]
        [SolrField("name")]
        public string Name { get; set; }
        [SolrField("type")]
        public string Type {get; set;}
    }
    public class Category : SolrSearchEntity
    {        
        public Category()
        {
           Type = "Category";
        }
    }
    public class Item : SolrSearchEntity
    {
        public Item()
        {
            Type = "Item";
        }
    }
