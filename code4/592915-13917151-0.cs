    Stream fs = FileUpload1.PostedFile.InputStream;
    BinaryReader br = new BinaryReader(fs);  //reads the   binary files
    Byte[] bytes = br.ReadBytes((Int32)fs.Length);  //counting the file length into bytes
    query = "insert into Excelfiledemo(Name,type,data)" + " values (@Name, @type, @Data)"; //insert query
    com = new SqlCommand(query, con);
    com.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename1;
    com.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
    com.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
    com.ExecuteNonQuery();
    Label2.ForeColor = System.Drawing.Color.Green;
    Label2.Text = "File Uploaded Successfully";
