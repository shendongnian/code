    void DoWork()
    {
        IDataManipulationService client = new DataManipulationServiceClient();
        try
        {
            using(FileStream stream = _SelectedFile.OpenRead())
            {
                int streamLength = (int)_SelectedFile.Length
                ServerAvailable = false;
                bool startRead = true;
                int bytesRead;
                int offset = 0;
                while((bytesRead = stream.Read(_Buffer, 0, _ReadSize)) > 0)
                {
                    offset += bytesRead;
                    Task<UploadState> task = client.UploadChunk(_Buffer, streamLength, FileName, offset, bytesRead);
                    while(true)
                    {
                        if(task.IsCompleted)
                        {
                            UploadState state = task.Result;
                            break;
                        }
                        if(task.IsFaulted)
                        {
                            var exception = task.Exception;
                            //Deal with errors
                            break;
                        }
                    }
                    if(state == UploadState.Error)
                        //error Handling
                    if(state == UploadState.Corrupt)
                        //Retry send
                    if(state == UploadState.Success)
                        continue;
                }
            }
        }
        catch(Exception e) {} //TODO: Replace Exception with some meaningful exception.
        finally
        {
            ServerAvailable = true;
        }
    }
    enum UploadState
    {
        Success,
        Error,
        Corrupt
    }
