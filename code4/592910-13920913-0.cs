            public AsyncCompletedEventHandler DownloadFileCompleted(string filename)
            { 
                Action<object,AsyncCompletedEventArgs> action = (sender,e) =>
                {
                    var _filename = filename;
                    
                    if (e.Error != null)
                    {
                        throw e.Error;
                    }
                    if (!_downloadFileVersion.Any())
                    {
                        complited = true;
                    }
                    DownloadFile();
                };
                return new AsyncCompletedEventHandler(action);
            }
