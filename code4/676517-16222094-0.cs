     protected void Page_Load(object sender, EventArgs e)
     {
        if (!IsPostBack)
        {
           comboTown.DataSource = new List<string> { "TownOne", 
                                                     "TownTwo", 
                                                     "TownThree", 
                                                     "TownFour" 
                                                   };
                comboTown.DataBind();
        }
     }
     
     protected void btnSetSelectedValue_Click(object sender, EventArgs e)
     {
            comboTown.SelectedValue = "TownThree";
     }
