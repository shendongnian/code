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
    
            grdExport.RenderControl(hw);
    
            //style to format numbers to string
    
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
    
            Response.Write(style);
    
            Response.Output.Write(sw.ToString());
    
            Response.Flush();
    
            Response.End();
    
        }
