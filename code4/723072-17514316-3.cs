        [XmlRoot("rowset")]
        public class CharacterList
        {
            public CharacterList() { Characters = new List<Character>(); }
            [XmlElement("row")]
            public List<Character> Characters { get; set; }
        }
        public class Character
        {
            [XmlAttribute("name")]
            public  string name { get; set; }
            [XmlAttribute("characterID")]
            public int Id { get; set; }
            [XmlAttribute("corporationName")]
            public string corporationName { get; set; }
            [XmlAttribute("corporationID")]
            public int corporationId { get; set; }
        }
