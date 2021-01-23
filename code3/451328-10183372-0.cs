    public partial class WebForm1 : System.Web.UI.Page
        {
            public bool MyProperty { get; set; }
    
           protected void Page_PreInit(object sender,EventArgs e)
           {
               MyProperty = true;
           }
    
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
        }
