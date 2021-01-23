    for (int j = 0; j < count; j++) // here is file iteration
    {
       for (int i = 0; i < count; i++) // here is dupe check
       {
          if (GridViewEfile.Rows[i].Cells[1].Text == FileName)
          {
              Label2.Text = "File already in the list";
              break;
          }
       }
                            
       dr = dt.NewRow();
       dr["File Name"] = FileName;
       if (size > 0)
          dr["File Size"] = size.ToString() + " KB";
       else
          Label2.Text = "File size cannot be 0";
    
       dt.Rows.Add(dr);
    
       GridViewEfile.DataSource = dt;
    
       GridViewEfile.DataBind();
       }
    }
