    byte []objData=null;
    using (MemoryStream memStream = new MemoryStream())
     {
        using (FileStream fileStream = File.Open(txtDICOMFilePath.Text, FileMode.Open))
        {
             fileStream.CopyTo(memStream);
        }
        int intL = Convert.ToInt32(memStream.Length);
        objData = new byte[intL];
        memStream.Read(objData,0,objData.Length);
     }
    SqlCom.Parameters.Add("@ImageData",SqlDb.Image,objData.Length).Value=objData;
