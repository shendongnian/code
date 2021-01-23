    public partial class UploadMany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void uploadButton_Clicked(object sender, EventArgs e)
        {
            var allFiles = Request.Files;
            for (int fileIndex = 0; fileIndex < allFiles.Count; fileIndex++)
            {
                HttpPostedFile oneFile = allFiles[fileIndex];
                if (oneFile.ContentLength > 0)
                {
                    //do something with each uploaded file here
                    int i = 0;
                }
            }
        }
    }
