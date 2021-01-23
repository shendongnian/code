    protected void download(object sender, EventArgs e)
            {
                string fname = "Excel_Sheet_Format.xlsx";
                string path = "C:/Users/dell/Desktop/Excel_Sheet_Format.xlsx";
                string name = Path.GetFileName(path);
                string ext = Path.GetExtension(path);
                Response.AppendHeader("content-disposition","attachment; filename=" + name);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.WriteFile(path);
                Response.End();    
            }
