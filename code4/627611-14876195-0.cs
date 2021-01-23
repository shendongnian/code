    public void UploadAndMoveFile()
            {
                bool success = false;
                string path = @"\\geodis\";
                string archive = @"\\Archive\";
                string[] files = Directory.GetFiles(path);
                if (files.Count() == 0)
                {
    //no files
                }
    
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string fileSource = path + fileName;
                    string fileDestination = archive + fileName;
                    string handle;
                    string ftp = @"\IN\"+fileName;
                    handle = sftp.OpenFile(ftp, "writeOnly", "createTruncate");
                    if (handle == null)
                    {
                        Console.WriteLine(sftp.LastErrorText);
                        return;
                    }
                    success = sftp.UploadFile(ftp, fileSource);
                    if (success == true)
                    {
                        AppendLogFile("Uploading File Succeeded", "Uploade File", fileName);
                        System.IO.File.Move(fileSource, fileDestination);
                        AppendLogFile("Moving File Succeeded", "Moving File", fileName);
                    }
                    else
                    {
                       // no files
                    }
                }
            }
