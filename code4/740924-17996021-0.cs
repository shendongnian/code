        private Double m_Width;
        public Double Width
        {
            get { return (Dimensions.Width); }
            set
            {
                m_Width = value;
                _dimension = new Size(m_Width, m_Height);
            }
        }
        private Double m_Height;
        public Double Height
        {
            get { return (Dimensions.Height); }
            set
            {
                m_Height = value;
                _dimension = new Size(m_Width, m_Height);
            }
        }
        private Size _dimension;
        public Size Dimensions
        {
            get { return _dimension; }
            set
            {
                _dimension = value;
                OnPropertyChanged("Dimensions");
            }
        }
