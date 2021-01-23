        private async SetAlbumSource()
        {
            var source = await AlbumThumbnail.OpenReadAsync();
            bmp = new BitmapImage()
            bmp.SetSource = source;
            RaisePropertyChanged("AlbumSource");
        }
    
        BitmapImage bmp;
        public BitmapImage AlbumSource
        {
            get
            {
                if (bmp == null) // might need a better sync mechanism but you get the idea
                    SetAlbumSource();
    
                return bmp;
            }
        }
