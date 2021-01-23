        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                foreach (string s in Request.Files)
                {
                    HttpPostedFile file = Request.Files[s];
    
                    int fileSizeInBytes = file.ContentLength;
                    string fileName = Request.Headers["X-File-Name"];
                    string fileExtension = "";
    
                    if (!string.IsNullOrEmpty(fileName))
                        fileExtension = Path.GetExtension(fileName);
    
                    // IMPORTANT! Make sure to validate uploaded file contents, size, etc. to prevent scripts being uploaded into your web app directory
                    string savedFileName = Path.Combine(@"C:\Temp\", Guid.NewGuid().ToString() + fileExtension);
                    file.SaveAs(savedFileName);
                }
            }
        }
