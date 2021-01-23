     public override void OnLoad(EventArgs e)
     {
         if(!Page.IsPostBack)
         {
            if (Session["PersistedCounter"] == null)
                Session["PersistedCounter"] = "0";
            Label1.Text = Session["PersistedCounter"];
         }
     }
     protected void Button_Click(object sender, EventArgs e)
     {
         int oldValue = int.Parse(Label1.Text);
         Label1.Text = (oldValue + 1).ToString();
         Session["PersistedCounter"] = Label1.Text;
     }
