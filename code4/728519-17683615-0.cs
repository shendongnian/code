        private async void btnDownload_Click( object sender, System.Windows.RoutedEventArgs e )
            {
            string fileID = "file.17ff6230f5f26b89.17FF6230F5F26B89!1658";
            string filename = "myDownloadFile1.txt";
            var liveClient = new LiveConnectClient( LiveHelper.Session );
            // Download the file
            await liveClient.BackgroundDownloadAsync( fileID + "/Content", new Uri( "/shared/transfers/" + filename, UriKind.Relative ) );
            // Read the file
            var FileData = await LoadDataFile<string>( filename );
            Debug.WriteLine( "FileData: " + (string)FileData );
            }
        public async Task<string> LoadDataFile<T>( string fileName )
            {
            // Get a reference to the Local Folder
            string root = ApplicationData.Current.LocalFolder.Path;
            var storageFolder = await StorageFolder.GetFolderFromPathAsync( root + @"\shared\transfers" );
            bool isFileExist = await StorageHelper.FileExistsAsync( fileName, storageFolder );
            if ( isFileExist )
                {
                // Create the file in the local folder, or if it already exists, just replace
                StorageFile storageFile = await storageFolder.GetFileAsync( fileName );
                if ( storageFile != null )
                    {
                    // Open it and read the contents
                    Stream readStream = await storageFile.OpenStreamForReadAsync();
                    using ( StreamReader reader = new StreamReader( readStream ) )
                        {
                        string _String = await reader.ReadToEndAsync();
                        reader.Close();
                        return _String;
                        }
                    }
                return string.Empty;
                }
            return string.Empty;
            }
        }
