    //Create Binary Data Stream  
        string filePath = Server.MapPath("APP_DATA/TestDoc.docx");
        string filename = Path.GetFileName(filePath);
        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        BinaryReader br = new BinaryReader(fs);
        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        br.Close();
        fs.Close();
    
    --------------------
    //insert the file into database
    
    string strQuery = "insert into tblFiles(Name, ContentType, Data) values (@Name, @ContentType, @Data)";
    SqlCommand cmd = new SqlCommand(strQuery,conn);
    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;
    cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = "application/vnd.ms-word";
    cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
    cmd.ExecuteNonQuery();
