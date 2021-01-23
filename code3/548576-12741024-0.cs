    try
    {
        grd_Order.SaveClicked(sender, e);
       //This is a button's Clicked event, which redirects to the same page after saving. 
    }
    catch (Exception ex)
    {
        lbl_Error.Text = "Error Occured " + ex.Message;
    }
