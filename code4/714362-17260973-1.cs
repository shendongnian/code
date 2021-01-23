    [Serializable]
    [XmlRoot(ElementName = "Collection")]
    public class Collection
    {
        public Collection() 
        {
            Artiesten = new List<Artiest>();
            Albums = new List<Album>();
            Nummers = new List<Nummer>();
        }
    
        public List<Artiest> Artiesten { get; set; }
        public List<Album> Albums { get; set; }
        public List<Nummer> Nummers { get; set; }
    
    }
    
    [Serializable]
    public class Artiest
    {
        [XmlAttribute("artiestid")]
        public int ArtiestId { get; set; }
        [XmlElement(ElementName = "Naam")]
        public String Naam { get; set; }
    
        public List<Album> Albums { get; set; } 
    }
