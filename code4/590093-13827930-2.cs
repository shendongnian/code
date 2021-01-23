        private readonly ObservableCollection<BitmapRow> m_ImageCollection = new ObservableCollection<BitmapRow>();
        public IEnumerable<BitmapRow> ImageCollection
        {
            get { return m_ImageCollection; }
        }
        void LoadImages()
        {
            var allImages = new List<Bitmap>();
            ResourceManager rm = Properties.Resources.ResourceManager;
            ResourceSet rs = rm.GetResourceSet(new CultureInfo("en-US"), true, true);
            if (rs != null)
            {
                var images =
                  from entry in rs.Cast<DictionaryEntry>()
                  where entry.Value is Bitmap
                  select entry;
                foreach (DictionaryEntry img in images)
                {
                    var bmp = img.Value as Bitmap; //one type cast
                    if (bmp!=null)
                    {
                        allImages.Add(bmp);
                    }
                }
                //now load the images in allImages in 3s into BitmapRows and add to m_ImageCollection 
                //I'll leave this bit up to you
            }
        }
