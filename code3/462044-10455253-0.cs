    private void button1_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        using (
            var sql =
                new SqlConnection(
                    @"Data Source=PC-PC\PC;Initial Catalog=Test;Integrated Security=True")
            )
        {
            using (
                var cmd = new SqlCommand
                              {
                                  Connection = sql,
                                  CommandText =
                                      "select Image from Entry where EntryID = @EntryID"
                              })
            {
                cmd.Parameters.AddWithValue(
                    "@EntryID",
                    Convert.ToInt32(textBox1.Text));
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds, "Images");
                }
            }
        }
    
        var imagesTable = ds.Tables["Images"];
        var imagesRows = imagesTable.Rows;
        var count = imagesRows.Count;
    
        if (count <= 0)
            return;
        var imageColumnValue =
            imagesRows[count - 1]["Image"];
        if (imageColumnValue == DBNull.Value)
            return;
    
        var data = (Byte[]) imageColumnValue;
        using (var stream = new MemoryStream(data))
        {
            pictureBox1.Image = Image.FromStream(stream);
        }
    }
