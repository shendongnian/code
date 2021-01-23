    try
    {
        RC4Engine myRC4Engine = new RC4Engine();
        myRC4Engine.EncryptionKey = "ab48495fdjk4950dj39405fk";
    
        XDocument doc = new XDocument(
            new XDeclaration("1.0", "iso-8859-1", null),
            new XElement("batch"));
    
        foreach (DataRow lobjbaseBatchDetail in dt.Rows)
        {
            myRC4Engine.InClearText = lobjbaseBatchDetail[3].ToString();
            myRC4Engine.Encrypt();
    
            strCardid = lobjbaseBatchDetail[0].ToString();
            strBatchid = lobjbaseBatchDetail[1].ToString();
            strid = strCardid + strBatchid + lobjbaseBatchDetail[2].ToString();
            XElement data = new XElement("data");
            data.Add(new XAttribute("cardid", strid));
            data.Add(new XAttribute("pinnumber", myRC4Engine.CryptedText));
            doc.Root.Add(data);
        }
            SqlParameter[] arrParam = new SqlParameter[1];
    
            arrParam[0] = new SqlParameter("@BATCHUPLOAD_XML", SqlDbType.Text );
            arrParam[0].Direction = ParameterDirection.Input;
            arrParam[0].Value = doc.ToString(SaveOptions.DisableFormatting);
    
            iResult = SqlHelper.ExecuteNonQuery(objTrans, CommandType.StoredProcedure, "test_proc", arrParam);
            objTrans.Commit();
    }
    catch(Exception ex)
    {
        objTrans.Rollback();
        throw new Exception("Upload failed :" + ex.Message);
    } 
      
