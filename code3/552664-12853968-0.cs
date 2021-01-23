    SqlCommand cmd = new SqlCommand("select IMAGEDT from FTAB", new SqlConnection("your connection string"));
    object data = cmd.ExecuteScalar();
    byte[] imgBytes = (byte[])data;
    
    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
    
    string filePath = Server.MapPath("temp") + "//" + "img"+DateTime.Now.Ticks.ToString()+".png";
    FileStream fs = File.Create(filePath);
    fs.Write(imgBytes, 0, imgBytes.Length);
    fs.Flush();
    fs.Close();
    
    img.ImageUrl = filePath;
