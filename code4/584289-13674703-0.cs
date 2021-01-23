    const string path = "~/Control1.ascx";
    HtmlGenericControl div;
     protected void Page_Load(object sender, EventArgs e){
       
       div = new HtmlGenericControl("div");
        div.Attributes.Add("runat", "server");
        var userControl = LoadControl(path);
      if (userControl != null)
          div.Controls.Add(userControl);
      this.form1.Controls.Add(div);
    }
