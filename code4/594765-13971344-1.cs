    using (StreamReader sr = new StreamReader(@"D:\Temp\fileread\readtext.txt"))
    {
        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            var dr = dt.NewRow(); //use newrow to create new row
            for (int i = 0; i < parts.Length; i++)
            {
                dr[i] = parts[i];
            }
            
            dt.Rows.Add(dr); //add row to datatable now
        }
        sr.Close();
    }
    //bind datatable to Gridview after we load file into dt
    MyGridView.DataSource = dt;
    MyGridView.DataBind();
