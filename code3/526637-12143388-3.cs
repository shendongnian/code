     //Use   BitmapImage bitmap = GetResourceTextFile(GetResourcePath("Images/animaha135.gif"));
        public BitmapImage GetResourceTextFile(string filename)
        {
            string result = string.Empty;
            using (Stream stream = this.GetType().Assembly.GetManifestResourceStream(String.Format("{0}.{1}",this.GetType().Assembly.GetName().Name,filename)))
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = stream;
                bi.EndInit();
                return bi;
            }
         
        }
