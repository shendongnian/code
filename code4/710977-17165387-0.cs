    protected void Page_Load(object sender, EventArgs e)
    {
         rptUsers.DataSource = users;
         rptUsers.DataBind();
    }
    protected void rptUsers_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
          {
             User user = (User)e.Item.DataItem;
             Label email = (Label)e.Item.FindControl("email");
             Label name = (Label)e.Item.FindControl("name");
             Label familyname = (Label)e.Item.FindControl("familyname");
             Label datejoined = (Label)e.Item.FindControl("datejoined");
             email.Text = user.EmalAddress;
             name.Text = user.Name;
             familyname.Text = user.FamilyName;
             datejoined.Text = user.DateJoined.ToString();
          }
     }
     protected void btnSubmit_OnClick(object sender, EventArgs e)
     {
         //submit
     }
