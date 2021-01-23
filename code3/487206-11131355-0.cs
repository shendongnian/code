    if(!IsPostBack)
    {
          eval1 = new RadioButtonList();
          eval1.Items.Add(new ListItem("Agree","1"));
          eval1.Items.Add(new ListItem("Somewhat Agree","2"));
          eval1.Items.Add(new ListItem("Disagree","3"));
          eval1.Attributes.Add("runat", "server");
          this.Session["eval1"] = eval1;
    
    }
