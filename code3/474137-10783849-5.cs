    [JsonObject(MemberSerialization.OptIn)]
    public class MyClass
    {
        private string m_imagePath;
       
        [JsonProperty]
        public string Name { get; set; }
        
        // not serialized because mode is opt-in
        public Image Image { get; private set; }
        [JsonProperty]
        public string ImagePath
        {
            get { return m_imagePath; }
            set
            {
                m_imagePath = value;
                Image = Image.FromFile(m_imagePath);
            }
        }
    }
