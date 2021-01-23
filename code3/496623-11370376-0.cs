    [Serializable]
    public class ProfileBasics
    {
        /// <summary>
        ///   Gets or sets the about me section
        /// </summary>
        [XmlElement("AboutMe")]
        public string AboutMe {get; set;}
        /// <summary>
        ///   Gets or sets the city name for the zip code
        /// </summary>
        [XmlElement("City")]
        public string City {get; set;}
     }
