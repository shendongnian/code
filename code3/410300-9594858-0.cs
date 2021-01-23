    private readonly static string UTF8_BYTE_ORDER_MARK =
        Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble(), 0, Encoding.UTF8.GetPreamble().Length);
    
    
            private string GetStringContentsOfFile(string path)
            {
                Uri filePath = new Uri(path);
                var jsonFileTask = StorageFile.GetFileFromApplicationUriAsync(filePath).AsTask();
                jsonFileTask.Wait();
                var jsonFile = jsonFileTask.Result;
    
                var getStringContentsTask = FileIO.ReadTextAsync(jsonFile, Windows.Storage.Streams.UnicodeEncoding.Utf8).AsTask();
                getStringContentsTask.Wait();
                var text = getStringContentsTask.Result;
    
                // FileIO.ReadTextAsync copies the UTF8 byte order mark into the result string. Strip the byte order mark
                text = text.Trim(UTF8_BYTE_ORDER_MARK.ToCharArray());
    
                return text;
    
            }
