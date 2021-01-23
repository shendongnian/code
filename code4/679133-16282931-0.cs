       protected void Page_Load(object sender, EventArgs e)
    {
           if(!IsPostBack)
           {
            DropDownList criteriaType = (DropDownList)DetailsView1.FindControl("CriteriaType");
            if (criteriaType.SelectedValue == "TMEL Table")
            {
                DetailsView1.Fields[5].Visible = true;
                DetailsView1.Fields[6].Visible = false;
                DetailsView1.Fields[7].Visible = false;
    
            }
            else if ((criteriaType.SelectedValue == "Risk Matrix"))
            {
                DetailsView1.Fields[5].Visible = true;
                DetailsView1.Fields[6].Visible = true;
                DetailsView1.Fields[7].Visible = true;
                DetailsView1.Fields[8].Visible = true;
            }
            else if ((criteriaType.SelectedValue == "Alarm Rationalization"))
            {
                DetailsView1.Fields[5].Visible = true;
                DetailsView1.Fields[6].Visible = true;
                DetailsView1.Fields[7].Visible = true;
                DetailsView1.Fields[8].Visible = true;
            }
            else if (criteriaType.SelectedValue == "Select a Type")
            {
                DetailsView1.Fields[5].Visible = false;
                DetailsView1.Fields[6].Visible = false;
                DetailsView1.Fields[7].Visible = false;
            }
        }
      }
