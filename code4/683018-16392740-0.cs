      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            TextBox1.Text = (Session["Test"] ?? "").ToString();
         }
      }
      protected void Button1_Click(object sender, EventArgs e)
      {
         Session["Test"] = TextBox1.Text;
      }
