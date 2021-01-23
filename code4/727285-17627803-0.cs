    protected void Button1_Click(object sender, EventArgs e)
    {       
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox ch = (CheckBox)GridView1.FindControl("chkid");
            if (ch != null)
            {
                if (ch.Checked)
                {
                    Response.Write("ch= true");
                    Label1.Text = GridView1.Rows.ToString();
                }
                else
                    Response.Write("ch= false");
            }
        }                 
     }
