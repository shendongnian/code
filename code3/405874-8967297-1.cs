        public class MyListWrapper<T> 
        {
           public MyListWrapper()
           {
              Data = new List<T>();
           }
           [XmlAttribute(AttributeName="x")]
           public string Xxx { get; set; }
           [XmlElement]
           public List<T> Data { get; set; }
        }
