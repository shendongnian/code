     protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
     {
         if (DropDownList1.SelectedValue != "0")
         {
             FormView2.DataBind();
             Label12.Text = "";
             Label13.Text = "";
            
             Button2_Click(sender, e);
             Button5.Visible = true;
             Label19.Visible = false;
             UpdatePanel4.Visible = true;
         }
         else
         {
             UpdatePanel4.Visible = false;
             Button5.Visible = false;
             Label19.Visible = true;
         }
     }
