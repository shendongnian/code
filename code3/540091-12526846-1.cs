    protected void grdCapTrans_SelectionChanged(object sender, EventArgs e)
    { 
       
        UpdatePanel1.Update();
        txtFullName.Text = grdCapTrans.GetSelectedFieldValues("Description")[1].ToString();
       
        message.InnerHtml = "Happy";
        
           
    }
