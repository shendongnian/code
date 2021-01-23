       protected void lnkbtnDownload_Click(object sender, EventArgs e)
        {
            string url = "PrintArticle.aspx?articleID=" + Request["articleID"] + "&download=yes&Language=" + Request["Language"];
            string args = string.Format("\"{0}\" - ", "http://xyz.net/" + url);
            var startInfo = new ProcessStartInfo(Server.MapPath("bin\\wkhtmltopdf.exe"), args)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true
    
            };
            var proc = new Process { StartInfo = startInfo };
            proc.Start();
    
            string output = proc.StandardOutput.ReadToEnd();
            byte[] buffer = proc.StandardOutput.CurrentEncoding.GetBytes(output);
            proc.WaitForExit();
            proc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=download.pdf");
            Response.BinaryWrite(buffer);
            Response.End();
        }
