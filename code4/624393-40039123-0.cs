            string FileName = System.IO.Path.GetFileName(e.FullPath);
            if(IsAvailable(System.IO.Path.Combine(RecievedPath,FileName)))
            {
                ProcessMessage(FileName);
            }
        }
