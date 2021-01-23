     protected void btnExportExcel_Click(object sender, EventArgs e)
            {
                Response.Clear();
                Response.Buffer = true;
    
                Response.AddHeader("content-disposition",
                 "attachment;filename=GridViewExport.xls");
    
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
    
                grdExport.AllowPaging = false;
                oMailing.GetData(out ODs);
                grdExport.DataSource = ODs;
                grdExport.DataBind();
    
                //Change the Header Row back to white color
                grdExport.HeaderRow.Style.Add("background-color", "#FFFFFF");
    
                //Apply style to Individual Cells
                grdExport.HeaderRow.Cells[0].Style.Add("background-color", "green");
    
                grdExport.HeaderRow.Cells[1].Style.Add("background-color", "green");
    
                grdExport.HeaderRow.Cells[2].Style.Add("background-color", "green");
    
                grdExport.HeaderRow.Cells[3].Style.Add("background-color", "green");
    
                grdExport.HeaderRow.Cells[4].Style.Add("background-color", "green");
                
                for (int i = 0; i < grdExport.Rows.Count; i++)
                {
                    GridViewRow row = grdExport.Rows;
                    
                    //Change Color back to white
                    row.BackColor = System.Drawing.Color.White;
                    
                    //Apply text style to each Row
                    row.Attributes.Add("class", "textmode");
    
                    //Apply style to Individual Cells of Alternating Row
                    if (i % 2 != 0)
                    {
                        row.Cells[0].Style.Add("background-color", "#C2D69B");
                        row.Cells[1].Style.Add("background-color", "#C2D69B");
                        row.Cells[2].Style.Add("background-color", "#C2D69B");
                        row.Cells[3].Style.Add("background-color", "#C2D69B");
                        row.Cells[4].Style.Add("background-color", "#C2D69B");
                    }
    
                }
                grdExport.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
