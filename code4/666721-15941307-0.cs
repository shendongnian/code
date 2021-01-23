     protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
    
            Response.Buffer = true;
            Response.AddHeader("content-disposition","attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
    
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView.AllowPaging = false;
    
            // Re-Bind data to GridView 
    
            using (MSEntities1 CompObj = new MSEntities1())
            {
               // code for bind grid view 
                GridView.DataBind();
            }
    
            // Change the Header Row back to white color
    
            GridViewC.Style.Add(" font-size", "10px");
           
            GridView.HeaderRow.Style.Add("background-color", "#FFFFFF");
    
    
            //Apply style to Individual Cells
    
            GridView.HeaderRow.Cells[0].Style.Add("background-color", "green");
            GridView.HeaderRow.Cells[1].Style.Add("background-color", "green");
            GridView.HeaderRow.Cells[2].Style.Add("background-color", "green");
            GridView.HeaderRow.Cells[3].Style.Add("background-color", "green");
            GridView.HeaderRow.Cells[4].Style.Add("background-color", "green");
            GridView.HeaderRow.Cells[5].Style.Add("background-color", "green");
            GridView.HeaderRow.Cells[6].Style.Add("background-color", "green");
            GridView.HeaderRow.Cells[7].Style.Add("background-color", "green");
    
    
            int k = GridView.Rows.Count;
    
            for (int i = 1; i < GridView.Rows.Count; i++)
            {
    
                GridViewRow row = GridView.Rows[i];
    
    
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
                    row.Cells[5].Style.Add("background-color", "#C2D69B");
                    row.Cells[6].Style.Add("background-color", "#C2D69B");
                    row.Cells[7].Style.Add("background-color", "#C2D69B");
                }
            }
            GridView.RenderControl(hw);
    
            // style to format numbers to string.
    
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
    
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
