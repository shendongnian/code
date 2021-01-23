        partial void FileContainersAddAndEditNew_Execute()
        {
            Dispatchers.Main.BeginInvoke(() =>
            {
                OpenFileDialog openDialog = new OpenFileDialog();
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
                            this.FileContainers.Details.Dispatcher.BeginInvoke(() =>
                            {
                                FileContainer fc = this.FileContainers.AddNew();
                                fc.File = fileBArray;
                                fc.FileName = "testing";
                                //fc.FileName = openDialog.File.Extension.ToString().ToLower();
                            });                           
                        }
                    }
                }
            });
