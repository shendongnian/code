        [XmlElement("Artiesten", typeof(List<Artiest>))]
        public List<Artiest> Artiesten { get; set; }
        [XmlElement("Albums", typeof(List<Album>))]
        public List<Album> Albums { get; set; }
        [XmlElement("Nummers", typeof(List<Nummer>))]
        public List<Nummer> Nummers { get; set; }
