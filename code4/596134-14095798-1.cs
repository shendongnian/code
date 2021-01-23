    public class GenericResponse<T>
    {
        [XmlArray("Content")]
        [XmlArrayItem("Item")]
        public List<T> ContentItems { get; set; }
        public GenericResponse()
        {
            this.ContentItems = new List<T>();
        }
    }
