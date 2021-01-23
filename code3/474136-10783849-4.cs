    private string m_imagePath;
        public Image Image { get; private set; }
        public string ImagePath
        {
            get { return m_imagePath; }
            set 
            {
                m_imagePath = value;
                Image = Image.FromFile(m_imagePath);
            }
        }
