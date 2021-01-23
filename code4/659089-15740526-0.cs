          Void GetCameraPhotos()
          {
            var imageList = new ObviousCollection<Images>();
            using (var library = new MediaLibrary())
            {
                //taking all albums
                PictureAlbumCollection allAlbums = library.RootPictureAlbum.Albums;
                //taking Camera Roll album separately from all album
                PictureAlbum cameraRoll = allAlbums.Where(album => album.Name == "Camera Roll").FirstOrDefault();
                // here you will get camera roll picture list
                var CameraRollPictures = cameraRoll.Pictures
                
            }
          }
