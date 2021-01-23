        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public Business GetBusiness()
        {
            var business = new Business();
            business.Locations = new List<string>();
            business.Locations.Add("location 1");
            business.Locations.Add("location 2");
            return business;
        }
        [XmlType(TypeName = "business")]
        public class Business
        {
            [XmlArray(ElementName = "locations")]
            [XmlArrayItem(ElementName = "location")]
            public List<string> Locations { get; set; }
        }
        //[XmlType(TypeName = "location")]
        //public class Location
        //{
        //    [XmlElement(ElementName = "name")]
        //    public string Name { get; set; }
        //}
