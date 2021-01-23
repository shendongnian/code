     private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\db1.mdb");
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Table1 (Product, Manufacturer, Description, Price,[Image]) VALUES (@Product,@Manufacturer,@Description,@Price,@Image)";
            byte[] yourPhoto = imageToByteArray(pictureBox1.Image);
            cmd.Parameters.AddWithValue("@Product", "yourProductValue");
            cmd.Parameters.AddWithValue("@Manufacturer","yourManufacturerValue");
            cmd.Parameters.AddWithValue("@Description", "yourDescriptionValue");
            cmd.Parameters.AddWithValue("@Price","yourPriceValue");
            cmd.Parameters.AddWithValue("@Image", yourPhoto);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    public byte[] imageToByteArray(System.Drawing.Image iImage)
    {
        MemoryStream mMemoryStream = new MemoryStream();
        iImage.Save(mMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
        return mMemoryStream.ToArray();
    }
