    protected void btnHey_Click(object sender, EventArgs e)
    {
     StringBuilder sb = new StringBuilder();
     sb.Append("<script language='javascript'>alert('HEY');</script>");
     // if the script is not already registered
     if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
          ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());
    }
