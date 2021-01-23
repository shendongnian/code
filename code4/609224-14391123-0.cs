    if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
                {
                    //get the content place holder from master page of your previous page where your controls are placed
                    //In this code the txtname textbox is placed inside ContentPlaceHolderID="MainContent"
                    var cp =PreviousPage.Master.FindControl("MainContent") as ContentPlaceHolder;
                    //find the textbox inside content place holder from previous page
                    TextBox txt1 = cp.FindControl("txtname") as TextBox;
                    label1.Text = "Value: " + txt1.Text;
                }
