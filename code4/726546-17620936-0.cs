        private async void btnUpload_Click( object sender, System.Windows.RoutedEventArgs e )
            {
            string filename = "myFile.txt";
            StorageFolder folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync( "Shared", CreationCollisionOption.OpenIfExists );
            folder = await folder.CreateFolderAsync( "transfers", CreationCollisionOption.OpenIfExists );
            var isolatedstorageFile= await folder.CreateFileAsync( filename, CreationCollisionOption.ReplaceExisting );
            using ( StreamWriter writer = new StreamWriter( await isolatedstorageFile.OpenStreamForWriteAsync() ) )
                {
                // convert to string
                var _String = Serialize( "this is a test file" );
                await writer.WriteAsync( _String );
                }
            await LiveHelper.Client.BackgroundUploadAsync( FolderID, new Uri( "/shared/transfers/" + filename, UriKind.Relative ), OverwriteOption.Overwrite );
            }
        private static string Serialize( object objectToSerialize )
            {
            using ( MemoryStream _Stream = new MemoryStream() )
                {
                try
                    {
                    var _Serializer = new DataContractJsonSerializer( objectToSerialize.GetType() );
                    _Serializer.WriteObject( _Stream, objectToSerialize );
                    _Stream.Position = 0;
                    StreamReader _Reader = new StreamReader( _Stream );
                    return _Reader.ReadToEnd();
                    }
                catch ( Exception e )
                    {
                    Debug.WriteLine( "\n******** Serialize:" + e.Message );
                    return string.Empty;
                    }
                }
            }
