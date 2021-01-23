    protected void SqlDataSource1_Updated(object sender, SqlDataSourceStatusEventArgs e)
    {
        int uniquecolumn= (int)e.Command.Parameters["@CheckCompTag"].Value;
        
      if (uniquecolumn == 0)
        {
            Label1.Text = "Success";
        }
        else
        {
            Label1.Text = "fail";
        }
      }
