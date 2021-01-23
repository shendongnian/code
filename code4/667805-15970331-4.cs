        partial void FileContainersAddAndEditNew_Execute()
        {
            
            var supportedFiles = "*.*";
            Dispatchers.Main.BeginInvoke(() =>
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Filter = "Supported files|" + supportedFiles;
                if (openDialog.ShowDialog() == true)
                {
                    using (System.IO.FileStream fileData = openDialog.File.OpenRead())
                    {
                        long fileLen = fileData.Length;
                        if (fileLen > 0)
                        {
                            Byte[] fileBArray = new Byte[fileLen--];
                            fileData.Read(fileBArray, 0, (int)fileLen);
                            fileData.Close();
                            var filename = openDialog.File.ToString().ToLower();
                            this.FileContainers.Details.Dispatcher.BeginInvoke(() =>
                            {
                                FileContainer fc = this.FileContainers.AddNew();
                                fc.File = fileBArray;
                                fc.FileName = filename;
                            });
                         
                        }
                    }
                }
            }); 
      
        }
