    protected void check1_SelectedIndexChanged(object sender, EventArgs e)
    {
       for (int z = 0; z < check1.Items.Count; z++)
       {
          string checking = "";
          if (check1.Items[z].Selected)
          {
             checking += "\u2022" + check1.Items[z].Text;
          }
       }
    
       Mail emailsystem = new Mail();
       emailsystem.GetEmail(comment.Text, StatusList.SelectedValue, checking );
    }
