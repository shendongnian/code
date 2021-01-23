       <img runat="server" 
                 src='<%# "getImage.aspx?ID=" + DataBinder.Eval(Container.DataItem, 
                 "ImageIdentity")  %>' ID="Img1"/>
       then in getimage.aspx 
    
        sqlConnection.Open();     
      SqlCommand sqlCommand = new SqlCommand("Select Images"  ,sqlConnection);
      Reader= sqlCommand.ExecuteReader(CommandBehavior.CloseConnection); 
      byte [] byteArray
     if(Reader.Read())
      {
         byteArray= (byte[]) Reader["Images"];
      }
      
      System.IO.MemoryStream mstream = new System.IO.MemoryStream(byteArray,0,byteArray.Length);
      System.Drawing.Image dbImage = System.Drawing.Image.FromStream( new System.IO.MemoryStream(byteArray));
      System.Drawing.Image thumbnailImage = dbImage.GetThumbnailImage(100,100,null,new System.IntPtr());
       thumbnailImage.Save(mstream,dbImage.RawFormat);
       Byte[] thumbnailByteArray = new Byte[mstream.Length];
       mstream.Position = 0;
       mstream.Read(thumbnailByteArray, 0, Convert.ToInt32(mstream.Length));
       Response.Clear();
       Response.ContentType="image/jpeg";
       Response.BinaryWrite(thumbnailByteArray);
       
      
       
