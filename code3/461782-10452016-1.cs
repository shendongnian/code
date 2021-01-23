    List<System.Web.UI.WebControls.Image> myButtons = new List<System.Web.UI.WebControls.Image>();
    
    Image myEditButton = new Image();
    myEditButton.ImageUrl = "~/images/themes/pencil.png";
    
    myButtons.Add(myEditButton);
    
    repButtons.DataSource = myButtons;
    repButtons.DataBind();
------
