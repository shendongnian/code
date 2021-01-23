        [XmlElement("Artiesten", typeof(Artiest))]
        public List<Artiest> Artiesten { get; set; }
        [XmlElement("Albums", typeof(Album))]
        public List<Album> Albums { get; set; }
        [XmlElement("Nummers", typeof(Nummer))]
        public List<Nummer> Nummers { get; set; }
