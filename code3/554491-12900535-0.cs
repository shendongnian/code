            var grid = new GridView
            {
                DataSource = from lineItem in rows
                             select new
                             {
                                 lineItem.ProjectName,
                                 lineItem.Sat,
                                 lineItem.Sun,
                                 lineItem.Mon,
                                 lineItem.Tue,
                                 lineItem.Wed,
                                 lineItem.Thu,
                                 lineItem.Fri
                             }
            };
            var fileName = string.Format("{0}:{1}", userName, timesheetDate);
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".xls");
            Response.ContentType = "application/msexcel";
            var sw = new StringWriter();
            var htw = new HtmlTextWriter(sw);
            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
