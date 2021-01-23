    public class GenericResponse<T>
    {
        [XmlArray("Content")]
        public List<T> ContentItems { get; set; }
        public GenericResponse()
        {
            this.ContentItems = new List<T>();
        }
    }
