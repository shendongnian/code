    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        foreach (ListItem listItem in cblCustomerList.Items)
        {
            if (listItem.Selected)
            {
                string GroupName = listItem.Value; // fix is here
            sqlcon.Open();
            string eno = ((TextBox)DetailsView1.FindControl("txteno")).Text.ToString();
            string empname = ((TextBox)DetailsView1.FindControl("txtempname")).Text.ToString();
            string sal = ((TextBox)DetailsView1.FindControl("txtsal")).Text.ToString();
            SqlCommand cmd = new SqlCommand("select eno from emp where eno = '" + eno + "'", sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblmsg.Text = "Employee No already exists";
            }
            else
            {
                dr.Close();
                sqlcmd = new SqlCommand("insert into emp values('" + eno + "', '" + empname + "','" + sal + "' , '" + GroupName + "')", sqlcon);
                sqlcmd.ExecuteNonQuery();
              //  DetailsView1.ChangeMode(DetailsViewMode.Insert);
            }
            sqlcon.Close();
           // LoadDet();
            }
        }
    }
