        private readonly ObservableCollection<BitmapRow> m_ImageCollection = new ObservableCollection<BitmapRow>();
        public IEnumerable<BitmapRow> ImageCollection
        {
            get { return m_ImageCollection; }
        }
        void LoadImages()
        {            
            ResourceManager rm = Properties.Resources.ResourceManager;
            ResourceSet rs = rm.GetResourceSet(new CultureInfo("en-US"), true, true);
            if (rs != null)
            {
                //var allImages = new List<Bitmap>();
                //var images =
                //  from entry in rs.Cast<DictionaryEntry>()
                //  where entry.Value is Bitmap
                //  select entry;                
                //foreach (DictionaryEntry img in images)
                //{
                //    var bmp = img.Value as Bitmap; //one type cast
                //    if (bmp!=null)
                //    {
                //        allImages.Add(bmp);
                //    }
                //}
                //neat alternative to all of above code:
                var allImages = rs.Cast<DictionaryEntry>().Values.OfType<Bitmap>().ToList();
                //or maybe you need to do this:
                var allImages = rs.Cast<DictionaryEntry>().Select(d=>d.Value).OfType<Bitmap>().ToList();
                //now load the images in allImages in 3s into BitmapRows and add to m_ImageCollection 
                //I'll leave this bit up to you to complete - you need to decide what to do
                //when the list is not an exact multiple of 3
                var max = allImages.Count();
                for(ini row = 0; row < max/3; row+=1)
                {
                   Bitmap a = allImages[row*3];
                   Bitmap b = allImages[row*3+1]; //TODO: needs index checking
                   Bitmap c = allImages[row*3+2]; //TODO: needs index checking
                   m_ImageCollection.Add(new BitmapRow(a,b,c));
                }
            }
        }
