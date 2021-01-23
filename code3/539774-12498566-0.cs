    public static void UploadFile(string filename, string filetype, string folderId)
        {
            var sFileName = filename;
            var sNsFileName = filename;
            var sFileType = filetype;
            var sFolderId = folderId;
            var uploadFile = new com.netsuite.webservices.File { attachFromSpecified = true, attachFrom = FileAttachFrom._computer };
            if (sFolderId != null)
            {
                var folderRef = new RecordRef { internalId = sFolderId };
                uploadFile.folder = folderRef;
            }
            // Specify the NetSuite filename
            if (sNsFileName != null)
                uploadFile.name = sNsFileName;
            uploadFile.fileTypeSpecified = true;
            if (sFileType != null)
            {
                if (sFileType.Trim().ToLower().Equals("plaintext"))
                    uploadFile.fileType = MediaType._PLAINTEXT;
                else if (sFileType.Trim().ToLower().Equals("image"))
                    uploadFile.fileType = MediaType._IMAGE;
                else if (sFileType.Trim().ToLower().Equals("csv"))
                    uploadFile.fileType = MediaType._CSV;
                else
                    uploadFile.fileType = MediaType._PLAINTEXT;
            }
            else
                uploadFile.fileType = MediaType._PLAINTEXT;
            uploadFile.content = LoadFile(sFileName);
            // Invoke add() operation to upload the file to NetSuite
            var response = Service.add(uploadFile);
            // Process the response
            if (response.status.isSuccess)
            {
                Console.WriteLine(
                    "\nThe file was uploaded successfully:" +
                    "\nFile Record key=" + ((RecordRef)response.baseRef).internalId +
                    "\nRenaming file");
            }
            else
            {
                Console.WriteLine("The file was not uploaded. Please notify the NetSuite team of the following error:");
                DisplayError(response.status.statusDetail);
            }
        }
        private static byte[] LoadFile(String sFileName)
        {
            byte[] data;
            try
            {
                FileStream inFile;
                using (inFile = new FileStream(sFileName, FileMode.Open, FileAccess.Read))
                {
                    data = new Byte[inFile.Length];
                    inFile.Read(data, 0, (int)inFile.Length);
                }
            }
            catch (Exception ex)
            {
                // Error creating stream or reading from it.
                Console.WriteLine(ex.Message);
                 return null;
            }
            return data;
        }
