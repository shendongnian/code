           var mediaLibrary = new Microsoft.Xna.Framework.Media.MediaLibrary();
            var location = mediaLibrary.SavePicture(tempJpeg + ".jpg", e.Result);
            string Path = location.GetPath();
            
            ShareMediaTask SMT = new ShareMediaTask();
            SMT.FilePath = Path;
            SMT.Show();
