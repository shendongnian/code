    MySQLConnection sqlcon;
    
    void savePic(Image pic)
    {
      using (MemoryStream ms = new MemoryStream())
      {
        pic.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        using (MySqlDataAdapter a = new MySqlDataAdapter())
        {
          a.InsertCommand = new MySqlCommand("insert into images(picture) values (@pic)", sqlcon);
          a.InsertCommand.Parameters.Add(new MySqlParameter("@pic", (object)ms.ToArray()));
          a.InsertCommand.ExecuteNonQuery();
        }
      }
    }
