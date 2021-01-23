    protected void check1_SelectedIndexChanged(object sender, EventArgs e)
    {
       string checking = "";
       for (int z = 0; z < check1.Items.Count; z++)
       {
          if (check1.Items[z].Selected)
          {
             checking += "\u2022" + check1.Items[z].Text;
          }
       }
    
       Mail emailsystem = new Mail();
       emailsystem.GetEmail(comment.Text, StatusList.SelectedValue, checking );
    }
