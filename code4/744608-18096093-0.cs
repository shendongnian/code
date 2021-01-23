    if(!IsPostBack){
     System.Web.UI.WebControls.LinkButton lbView = new System.Web.UI.WebControls.LinkButton();
     lbView.Text = "<br />" + "View";
     lbView.Click += new System.EventHandler(lbView_Click);
    
     tc.Controls.Add(lbView);
     tr.Cells.Add(tc);
    }
    
     protected void lbView_Click(object sender, EventArgs e)
     {
         Response.Redirect("contactus.aspx");
     }
