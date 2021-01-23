    bool isDuplicate = false;
    
    for (int i = 0; i < count; i++)
    {
        if (GridViewEfile.Rows[i].Cells[1].Text == FileName)
        {
             Label2.Text = "File already in the list";
             isDuplicate = true;
             break;
        }
    }
    
    for (int j = 0; j < count; j++)
    {
         dr = dt.NewRow();
         dr["File Name"] = GridViewEfile.Rows[j].Cells[1].Text;
         dr["File Size"] = GridViewEfile.Rows[j].Cells[2].Text;
         dt.Rows.Add(dr);
    }
    
    if (!isDuplicate)
    {
         if (size == 0)
         {
             Label2.Text = "File size cannot be 0";
         }
         else
         {
             dr = dt.NewRow();
             dr["File Name"] = FileName;
             dr["File Size"] = size.ToString() + " KB";
    
             dt.Rows.Add(dr);
         }
    }
    
    GridViewEfile.DataSource = dt;
    GridViewEfile.DataBind();
