    protected void Button7_Click(object sender, EventArgs e)
    {
        bool BindNeeded = false;
        SqlConnection connDelete = new SqlConnection("Data Source=19-20\\sqlexpress;" + "Initial Catalog = mpsip; Integrated Security = SSPI");
        connDelete.Open();
        String mySQL;
        try
        {
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                CheckBox CheckBox1 = (CheckBox)
                Repeater1.Items[i].FindControl("CheckBox1");
                if (((CheckBox)Repeater1.Items[i].FindControl("CheckBox1")).Checked)
                {
                    //This assumes data type of messageID is integer, change (int) to the right type
                    CheckBox CheckBox = (CheckBox)Repeater1.Items[i].FindControl("CheckBox1");
                    Literal litMessageId = (Literal)Repeater1.Items[i].FindControl("litMessageId");
                    string messageId = litMessageId.Text;
                    mySQL = string.Format("delete from messages where messageID = '{0}'", messageId);
                    SqlCommand cmdDelete = new SqlCommand(mySQL, connDelete);
                    cmdDelete.ExecuteNonQuery();
                    
                    // Continue your code here
                }
                else
                {
                    
                }
            }
                if (BindNeeded)
                {
                    Repeater1.DataBind();
                }
                else
                {
                    Response.Redirect("Messages.aspx");
                }
        }
            catch
        {
            Response.Redirect("Messages.aspx");
        }
   
    }
