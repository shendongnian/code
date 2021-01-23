       public MimeType GetMimeTypeFromFile(string filePath)
        {
            sbyte[] fileData = null;
            using (FileStream srcFile = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] data = new byte[srcFile.Length];
                srcFile.Read(data, 0, (Int32)srcFile.Length);
                fileData = Winista.Mime.SupportUtil.ToSByteArray(data);
            }
            MimeType oMimeType = GetMimeType(fileData);
            if (oMimeType != null) return oMimeType;
            //We haven't found the file using Magic (eg a text/plain file)
            //so instead use URLMon to try and get the files format
            Winista.MimeDetect.URLMONMimeDetect.urlmonMimeDetect urlmonMimeDetect = new Winista.MimeDetect.URLMONMimeDetect.urlmonMimeDetect();
            string urlmonMimeType = urlmonMimeDetect.GetMimeFromFile(filePath);
            if (!string.IsNullOrEmpty(urlmonMimeType))
            {
                foreach (MimeType mimeType in types)
                {
                    if (mimeType.Name == urlmonMimeType)
                    {
                        return mimeType;
                    }
                }
            }
            return oMimeType;
        }
