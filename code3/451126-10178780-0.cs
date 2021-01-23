     public override void OnLoad(EventArgs e)
     {
         if(!Page.IsPostBack)
           Label1.Text = "0";
     }
     protected void Button_Click(object sender, EventArgs e)
     {
         int oldValue = int.Parse(Label1.Text);
         Label1.Text = (oldValue + 1).ToString();
     }
