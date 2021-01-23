            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    var fileId = Guid.Parse(id);
                    var myFile = AppModel.MyFiles.SingleOrDefault(x => x.Id == fileId);
                    if (myFile != null)
                    {
                        byte[] fileBytes = myFile.FileData;
                        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, myFile.FileName);
                    }
                }
                catch
                {
                }
            }
            return null;
        }
