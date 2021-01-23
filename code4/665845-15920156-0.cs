     private ClientContext context;
     private Web web;
     private void UploadFile(FileInfo fileToUpload, string libraryTitle, string subfolderPath, bool fileOverwrite)
        {
            try
            {
                //Treatment of files and loading it to byte array []
                Stream str = null;
                Int32 strLen, strRead;
                str = fileToUpload.OpenRead();
                strLen = Convert.ToInt32(str.Length);
                byte[] strArr = new byte[strLen];
                strRead = str.Read(strArr, 0, strLen);
                 
                using (context = new ClientContext("http://localhost/"))
               {
                web = context.Web;
                
                //Defining where to find the files to tape record the library go
                List destinationList = web.Lists.GetByTitle(libraryTitle);
                //Creating a file
                var fciFileToUpload = new FileCreationInformation();
                fciFileToUpload.Content = strArr;
                //Must determine whether to upload files directly to the library or whether to upload the files to sub directories and stack your way to the file
                string uploadLocation = fileToUpload.Name;
                if (!string.IsNullOrEmpty(subfolderPath))
                {
                    uploadLocation = string.Format("{0}/{1}", subfolderPath, uploadLocation);
                }
                uploadLocation = string.Format("{0}/{1}/{2}", webUrl, libraryTitle, uploadLocation);
                //Sets the path to the file where you want to upload and subor whether to overwrite the file or not
                fciFileToUpload.Url = uploadLocation;
                fciFileToUpload.Overwrite = fileOverwrite;
                clFileToUpload = destinationList.RootFolder.Files.Add(fciFileToUpload);
                //load web,list.
                context.Load(web);
                context.Load(destinationList, list => list.ItemCount);
                context.Load(clFileToUpload);
                context.Load(clFileToUpload.ListItemAllFields);
                context.ExecuteQueryAsync(OnLoadingSucceeded, OnLoadingFailed);
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                unhideComponents();
            }
        }
        private void OnLoadingSucceeded(Object sender, ClientRequestSucceededEventArgs args)
        {
            Dispatcher.BeginInvoke(fileUploaded); // fileUploaded is function
        }
        private void OnLoadingFailed(object sender, ClientRequestFailedEventArgs args)
        {
            Dispatcher.BeginInvoke(fileNotUploaded); //fileNotUploaded is function
        }
