    public partial class info: System.Web.UI.UserControl
    {
        public string ID_Lbl {get;set;}
        public string Description_Lbl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            IDLabel.Text = ID_Lbl;
            DescriptionLabel.Text = Description_Lbl;
        }
    }
