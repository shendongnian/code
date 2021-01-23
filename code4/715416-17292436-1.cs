    **using FileOBjects;**
    using System; 
    using System.Data; 
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class gallery : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 CFileInfo oDetailedFileInfo = new CFileInfo(sFileName);  
            }
        }
