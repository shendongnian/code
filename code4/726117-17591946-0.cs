     private void ChangeBtn_Click(object sender, EventArgs e)
     {
     foreach(Control c in Page.Controls)
     {
       if (c.Controls.Count > 0)
       {
         foreach(Control c2 in c.Controls)
         {
            if (c2.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
            {
                myspan.InnerHtml = ((TextBox)c2).Text;
               ((TextBox)c2).Text = "";
            }
         }
      }
     }
