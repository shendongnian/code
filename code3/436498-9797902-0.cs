    DataTable dt = new DataTable("Name");
    dt.Columns.Add("Audio Asset");
    dt.Columns.Add("Image Asset");
    
    const int audioColIndex = 0;
    const int imageColIndex = 1;
    
    DataRow dr = dt.NewRow();
    dr[audioColIndex] = "A MP3";
    dr[imageColIndex] = "A picture";
    dt.Rows.Add(dr);
    
    dr = dt.NewRow();
    dr[audioColIndex] = "A MP4";
    dr[imageColIndex] = "A image";
    dt.Rows.Add(dr);
    
    DataGridView1.Datasource = dt;
