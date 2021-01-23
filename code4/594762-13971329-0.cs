    DataTable dt = new DataTable();
    for (int i = 0; i < 6; i++) 
        dt.Columns.Add(new DataColumn());
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
