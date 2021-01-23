	public class MyCoolModel : Base.BaseEntity
	{
		/// <summary>
        /// Contains XML data of the attributes
        /// </summary>
        public string AttributesData
        {
            get
            {
                var xElem = new XElement(
                    "items",
                    Attributes.Select(x => new XElement("item", new XAttribute("key", x.Key), new XAttribute("value", x.Value)))
                 );
                return xElem.ToString();
            }
            set
            {
                var xElem = XElement.Parse(value);
                var dict = xElem.Descendants("item")
                                    .ToDictionary(
                                        x => (string)x.Attribute("key"), 
                                        x => (string)x.Attribute("value"));
                Attributes = dict;
            }
        }
			
		//Some other stuff
		
		/// <summary>
		/// Some cool description
		/// </summary>
		[NotMapped]
		public Dictionary<string, string> Attributes { get; set; }
	}
