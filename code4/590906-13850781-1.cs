         Task<T> Download(string filePath)
         {             
                return dropbox.DownloadFileAsync(filePath)
                        .ContinueWith(task =>
                        {
                            returnArray = new byte[task.Result.Content.Length];
                            task.Result.Content.CopyTo(returnArray, 0);
                            return returnArray;
                        });
          }
