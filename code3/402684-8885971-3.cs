    namespace Site.UserControls.Base
    {
        public partial class Header : UserControlBase //UserControl
        {
            public string Testing { get { return "hello world!"; } }
            public string Testing2 = "hello world!";
    
            protected void Page_Load(object sender, EventArgs e)
            { }
        }
    }
