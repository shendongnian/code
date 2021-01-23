     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
       {
               if (e.CommandArgument=="InsertNew")
             {
             GridView testGrid=(Gridview)sender;
               TextBox txtName =(TextBox)testGrid.FooterRow.FindControl("txtSName");
            string strName=txtName.Text;   
              }
             }
