    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string incomingXml = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\" ?>" +
           "<ns2:group_lookup_result_list xmlns:ns2=\"http://ws.byu.edu/namespaces/gro/v1\">" +
               "<group_lookup_results>" +
                   "<group_lookup_result>" +
                       "<group_id>bradtest</group_id>" +
                       "<group_name>Brad's Test Group</group_name>" +
                       "<effective_date>2011-05-04T00:00:00-06:00</effective_date>" +
                       "<expiration_date>2014-01-10T23:59:59-07:00</expiration_date>" +
                   "</group_lookup_result>" +
                   "<group_lookup_result>" +
                       "<group_id>brjtest</group_id>" +
                       "<group_name>Bernt's Test Group</group_name>" +
                       "<effective_date>2011-05-05T00:00:00-06:00</effective_date>" +
                       "<expiration_date>2012-05-05T23:59:59-06:00</expiration_date>" +
                   "</group_lookup_result>" +
               "</group_lookup_results>" +
           "</ns2:group_lookup_result_list>";
            XmlSerializer searchResultSerializer = new XmlSerializer(typeof(GroupLookupResultList));
            System.IO.StringReader reader = new System.IO.StringReader(incomingXml);
            GroupLookupResultList resultList = (GroupLookupResultList)searchResultSerializer.Deserialize(reader);
            System.Diagnostics.Debug.WriteLine("Deserialized " + resultList.group_lookup_results.Count + " results");
    
        }
    }
    [SerializableAttribute()]
    [XmlTypeAttribute(TypeName = "group_lookup_result")]
    [XmlRootAttribute("group_lookup_result")]
    public class GroupLookupResult
    {
        private string _groupId;
        private string _groupName;
        public GroupLookupResult()
        {
            _groupId = "";
            _groupName = "";
        }
        [XmlElement("group_id", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string GroupID
        {
            get { return _groupId; }
            set { _groupId = value; }
        }
        [XmlElement("group_name", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }
    }
    [SerializableAttribute()]
    [XmlRootAttribute(ElementName = "group_lookup_result_list", IsNullable = false, Namespace = "http://ws.byu.edu/namespaces/gro/v1")]
    [XmlTypeAttribute(TypeName = "group_lookup_result_list", Namespace = "http://ws.byu.edu/namespaces/gro/v1")]
    public class GroupLookupResultList
    {
        private List<GroupLookupResult> _searchResults;
        public GroupLookupResultList() { }
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("group_lookup_result", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<GroupLookupResult> group_lookup_results
        {
            get { return _searchResults; }
            set { _searchResults = value; }
        }
    }
