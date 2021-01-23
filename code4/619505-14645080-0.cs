    Request.ContentType = "binary/octet-stream";
            Stream myStream = Request.InputStream;
            int iContentLengthCounter = 0;
            int maxlength = (int) myStream.Length;
            byte[] bFileWriteData = new byte[maxlength];
            string fileName = "D:\\myFile.zip";
            //FileStream oFileStream = new FileStream();
    
            while (iContentLengthCounter < maxlength)
           {
               iContentLengthCounter += Request.InputStream.Read(bFileWriteData, iContentLengthCounter, (maxlength - iContentLengthCounter));
           }
            System.IO.FileStream oFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
           oFileStream.Write(bFileWriteData, 0, bFileWriteData.Length);
           
            oFileStream.Close();
           Request.InputStream.Close();
