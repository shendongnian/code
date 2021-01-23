    IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
                    if (myIsolatedStorage.FileExists(FLTile))
                    {
                        myIsolatedStorage.DeleteFile(FLTile);
                    }
                    using (IsolatedStorageFileStream iso = new IsolatedStorageFileStream(FLTile, FileMode.OpenOrCreate, IsolatedStorageFile.GetUserStoreForApplication()))
                    {
                        WriteableBitmap1 .SaveJpeg(iso, 768, 200, 0, 100);
                        iso.Close();
                    }
                    if (myIsolatedStorage.FileExists(FLICKR_LIVE_TILE))
                    {
                        myIsolatedStorage.DeleteFile(FLICKR_LIVE_TILE);
                    }
                    using (
                 IsolatedStorageFileStream isoFileStream = new IsolatedStorageFileStream(FLICKR_LIVE_TILE, FileMode.OpenOrCreate,
                 IsolatedStorageFile.GetUserStoreForApplication()))
                    {
                        WriteableBitmap2 .SaveJpeg(isoFileStream, 336, 200, 0, 100);
                        isoFileStream.Close();
                    }
                   
                  
                 
               
                    var shellTileData = new FlipTileData
                    {
                        BackgroundImage = new Uri("isostore:" + FLICKR_LIVE_TILE, UriKind.RelativeOrAbsolute),
                        //BackContent = "Connectivity Slab",
                        SmallBackgroundImage = new Uri("isostore:" + FLICKR_LIVE_TILE, UriKind.RelativeOrAbsolute),
                        WideBackgroundImage = new Uri("isostore:" + FLTile, UriKind.RelativeOrAbsolute),
                        WideBackBackgroundImage = new Uri("isostore:" + FLTile, UriKind.RelativeOrAbsolute),
                        BackBackgroundImage = new Uri("isostore:" + FLICKR_LIVE_TILE, UriKind.RelativeOrAbsolute),
                    };
                    var tile = ShellTile.ActiveTiles.First();
                    tile.Update(shellTileData);
