            public BitmapImage GetPicture( string FileName )
            {
            // Work around for known bug in the media framework.  Hits the static constructors
            // so the user does not need to go to the picture hub first.
            MediaPlayer.Queue.ToString();
            MediaLibrary ml = null;
            PictureAlbum cameraRoll = null;
            PictureAlbum savedPictures = null;
            PictureAlbum samplePictures = null;
            PictureAlbum favoritePictures = null;
            int index = FileName.IndexOf( "\\" );
            string albumName = FileName.Remove( index, FileName.Length - index );
            string fileName = FileName.Remove( 0, index + 1 );
            foreach ( MediaSource source in MediaSource.GetAvailableMediaSources() )
                {
                if ( source.MediaSourceType == MediaSourceType.LocalDevice )
                    {
                    ml = new MediaLibrary( source );
                    PictureAlbumCollection allAlbums = ml.RootPictureAlbum.Albums;
                    foreach ( PictureAlbum album in allAlbums )
                        {
                        if ( album.Name == "Camera Roll" )
                            {
                            cameraRoll = album;
                            }
                        else if ( album.Name == "Saved Pictures" )
                            {
                            savedPictures = album;
                            }
                        else if ( album.Name == "Sample Pictures" )
                            {
                            samplePictures = album;
                            }
                        else if ( album.Name == "Favorite Pictures" )
                            {
                            favoritePictures = album;
                            }
                        }
                    }
                }
            PictureAlbum Album;
            switch ( albumName )
                {
                case "Camera Roll":
                    Album = cameraRoll;
                    break;
                case "Saved Pictures":
                    Album = savedPictures;
                    break;
                case "Sample Pictures":
                    Album = samplePictures;
                    break;
                case "Favorite Pictures":
                    Album = favoritePictures;
                    break;
                default:
                    Album = null;
                    break;
                }
            if ( Album == null )
                {
                return new BitmapImage();
                }
            BitmapImage b = new BitmapImage();
            foreach ( Picture p in Album.Pictures.Take( Album.Pictures.Count ) )
                {
                if ( fileName == p.Name )
                    {
                    b.SetSource( p.GetThumbnail() );
                    break;
                    }
                }
            return b;
            }
