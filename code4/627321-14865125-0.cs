        [Serializable]
        [XmlInclude(typeof(cat))]
        [XmlInclude(typeof(fish))]
        class animals
        {
             ....
        }
        public class cat:animal
        {
          public string size { get; set; }
          public string furColor { get; set; }
        }
    
        public class fish:animal
        {
          public string size { get; set; }
          public string scaleColor { get; set; }
        }
 
