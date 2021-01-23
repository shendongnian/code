            GridView1.AllowPaging = false;
            GridView1.DataBind();
            StringBuilder sb = new StringBuilder();
             
            for (int k = 0; k < GridView1.Columns.Count; k++)
            {
                //add separator
                sb.Append(GridView1.Columns[k].HeaderText+";");
               
            }
            
            //append new line
            sb.Append("\r\n");
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                for (int k = 0; k < GridView1.Columns.Count; k++)
                {
                    sb.Append(GridView1.Rows[i].Cells[k].Text+";");
                }
                sb.AppendLine();
            }
 
