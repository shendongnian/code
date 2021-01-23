          private void LoadImg()
        {
         
           //x is name of <Image name="x"/>
           x.Source = GetResourceTextFile(GetResourcePath("Images/animaha135.gif"));
           
        }
       
        private string GetResourcePath(string path)
        {
            return path.Replace("/", ".");
        }
        public BitmapFrame GetResourceTextFile(string filename)
        {
            string result = string.Empty;
            using (Stream stream = this.GetType().Assembly.GetManifestResourceStream(String.Format("{0}.{1}",this.GetType().Assembly.GetName().Name,filename)))
            {
                BitmapFrame bmp = BitmapFrame.Create(stream);
                return bmp;
            }
          
        }
       
