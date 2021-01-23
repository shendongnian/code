    public class BackgroundImageHolder
    {
        private static BackgroundImageHolder m_instance;
        private Bitmap m_backgroundImage;
        public event EventHandler BackgroundImageChanged;
        private BackgroundImageHolder() { }
        public static BackgroundImageHolder Instance
        {
            get
            {
                if (m_instance == null) m_instance = new BackgroundImageHolder();
                return m_instance;
            }
        }
    
        public Bitmap BackgroundImage
        {
            get { return m_backgroundImage; }
            set {
               m_backgroundImage = value;
               OnBackgroundImageChanged();
            }
        }
        protected void OnBackgroundImageChanged()
        {
            if (BackgroundImageChanged != null)
                BackgroundImageChanged(this, EventArgs.Empty);
        }
    }
