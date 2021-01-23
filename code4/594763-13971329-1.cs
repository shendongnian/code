    DataTable dt = new DataTable();
    dt.Columns.Add("Row No", typeof(Int32));
    dt.Columns.Add("Col No", typeof(Int32));
    dt.Columns.Add("Width", typeof(Int32));
    dt.Columns.Add("Height", typeof(Int32));
    dt.Columns.Add("ImageUrl", typeof(String));
    dt.Columns.Add("Description", typeof(String));
    using (StreamReader sr = new StreamReader(@"D:\Temp\fileread\readtext.txt"))
    {
        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            var row = dt.NewRow();
            for (int i = 0; i < parts.Length; i++)
            {
                row[i] = parts[i];
            }
            // important thing!
            dt.Rows.Add(row);
        }
        sr.Close();
    }
    MyGridView.DataSource = dt;
    MyGridView.DataBind();
