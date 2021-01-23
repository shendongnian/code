        public partial class ApplicationWSGlobal : System.Web.Services.WebService
        {
            private string UploadPath = @"";
            [WebMethod]
            public void SetUploadPath(string x)
            {
                UploadPath = x;
            }
            public ApplicationWSGlobal()
            {
                InitializeComponent();
            }
         }
