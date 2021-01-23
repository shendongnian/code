     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
       {
               if (e.CommandArgument=="InsertNew")
             {
               TextBox txtName =(TextBox) GridView1.FooterRow.FindControl("txtSName");
            string strName=txtName.Text;   
              }
             }
