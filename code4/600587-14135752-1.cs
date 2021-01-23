     gridViewTest_RowEditing(object sender, GridViewEditEventArgs e)
     {
    gridViewTest.EditIndex=e.NewEditIndex;
    Panel myPanel =    (Panel)gridViewTest.Rows(gridViewTest.EditIndex).FindControl("pnlPopup");
    Label myLabel = (Label)myPanel.Findcontrol("lblCustomerDetail");
       }
