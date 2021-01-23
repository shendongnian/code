    public static async Task UpdateTextContent(string contentItemId)
            {
                var storageFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync(TARGET_FOLDER);
                StorageFile sf = null;
                try
                {
                    //get content of the file make sure that it exist
                    sf = await storageFolder.GetFileAsync(TARGET_FILE);
                }
                catch (Exception ex)
                {
                   
                }
    
                if (sf != null)
                {
                    var targettxtfile = await Windows.Storage.FileIO.ReadTextAsync(sf);
    
                    var sbProcessedTextToWrite = new StringBuilder(targettxtfile);
  
                    if (targettxtfile.IndexOf(contentItemId) >= 0)
                    {
                        string startmarker = new StringBuilder("[").Append(contentItemId).Append("#start]").ToString();
                        string endmarker = new StringBuilder("[").Append(contentItemId).Append("#end]").ToString();
    
                        int start = sbProcessedTextToWrite.ToString().IndexOf(startmarker);
                        int end = sbProcessedTextToWrite.ToString().IndexOf(endmarker);
    
                        int slen = end + endmarker.Length - start; 
    
                        //compute position to remove
                        sbProcessedTextToWrite.Remove(start, slen);
                    }
                   
                    using (IRandomAccessStream fileStream = await sf.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        using (IOutputStream outputStream = fileStream.GetOutputStreamAt(0))
                        {
                            using (DataWriter dataWriter = new DataWriter(outputStream))
                            {
    
                                dataWriter.WriteString(sbProcessedTextToWrite.ToString());                            
    
                                await dataWriter.StoreAsync();
    
                                // For the in-memory stream implementation we are using, the flushAsync call 
                                // is superfluous,but other types of streams may require it.
                                await dataWriter.FlushAsync();
    
                                // In order to prolong the lifetime of the stream, detach it from the 
                                // DataWriter so that it will not be closed when Dispose() is called on 
                                // dataWriter. Were we to fail to detach the stream, the call to 
                                // dataWriter.Dispose() would close the underlying stream, preventing 
                                // its subsequent use by the DataReader below.
                                dataWriter.DetachStream();
                            }
    
                            //same here flush the outputStream as well
                            await outputStream.FlushAsync();
                        }
                    }
                }
    
    
            }
