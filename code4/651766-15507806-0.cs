           protected void Page_Load(object sender, EventArgs e)
            {
                string FName = Server.MapPath(@"Files\" + Request.QueryString["FileName"].ToString());
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + FName);
                Response.TransmitFile(FName);
                Response.End(); 
            }
