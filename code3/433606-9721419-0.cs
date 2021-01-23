    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected override void OnInit(EventArgs e)
        {
            Button b = new Button();
            b.ID = "Button" + i;
            b.Text = "Button" + i;
            b.Click += new EventHandler(b_Click);
            form1.Controls.Add(b);
        }
    
    }
    public partial class WebForm2 : System.Web.UI.Page
    {
        void b_Click(object sender, EventArgs e)
        {
            //some code
        }
    }
