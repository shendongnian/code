    [XmlRoot("autocomplete")]
    public class AutocompleteList
    {
        [XmlElement("url_template")]
        public string UrlTemplate { get; set; }
        
        [XmlElement("autocomplete_item")]
        public List<AutocompleteItem> Items { get; set; }
    }
    
    public class AutocompleteItem
    {
        [XmlElement("title")]
        public Title ItemTitle { get; set; }
    }
    
    public class Title
    {
        [XmlAttribute("short")]
        public string Short { get; set; }
    }
