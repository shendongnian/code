     protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            // Re-Bind data to GridView 
            using (CompMSEntities1 CompObj = new CompMSEntities1())
            {
                Start = Convert.ToDateTime(txtStart.Text);
                End = Convert.ToDateTime(txtEnd.Text);
                GridViewSummaryReportCategory.DataSource = CompObj.SP_Category_Summary(Start, End);
                SP_Category_Summary_Result obj1 = new SP_Category_Summary_Result();
                GridView1.DataBind();
               GridView1.Visible = true;
                ExportTable.Visible = true;
            }
            //Change the Header Row back to white color
            GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
           GridView1.Style.Add(" font-size", "10px");
        
     
            //Apply style to Individual Cells
            GridView1.HeaderRow.Cells[0].Style.Add("background-color", "green");
            GGridView1.HeaderRow.Cells[1].Style.Add("background-color", "green");
            GridView1.HeaderRow.Cells[2].Style.Add("background-color", "green");
            GridView1.HeaderRow.Cells[3].Style.Add("background-color", "green");
            GridView1.HeaderRow.Cells[4].Style.Add("background-color", "green");
            for (int i = 1; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];
                //Change Color back to white
                row.BackColor = System.Drawing.Color.White;
                //Apply text style to each Row
            //    row.Attributes.Add("class", "textmode");
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
            GridView1.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
