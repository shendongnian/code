    Response.ClearContent();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", "attachment;filename=UserList.xls");
            
            DataGrid grid = new DataGrid();
            grid.DataSource = <<DataList>>;
            grid.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grid.RenderControl(htw);
            Response.Write(htw.InnerWriter);
            
            Response.End();
