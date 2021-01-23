            //ds = new DataSet();
            //da.Fill(ds, "test_table");
            FileStream FS1 = new FileStream("image.jpg", FileMode.Create);
            if (ds.Tables["test_table"].Rows.Count > 0)
            {
                byte[] blob = (byte[])ds.Tables["test_table"].Rows[0]["pic"];
                FS1.Write(blob, 0, blob.Length);
                FS1.Close();
                FS1 = null;
                byte[] imageData = (byte[])cmd.ExecuteScalar();
                MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length);
                pictureBox2.Image = Image.FromStream(ms);
                
                
                pictureBox2.Image = Image.FromFile("image.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Refresh();
                pictureBox2.Image = Image.FromStream(new MemoryStream(blob));  
                pictureBox2.Image = Image.FromFile("image.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Refresh();
            }
