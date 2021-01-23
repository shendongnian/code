    protected void btnInsert_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(strCon);
        obj1.FirstName = txtName.Text;
        obj1.LastName = txtName1.Text;
        if (obj1.upDate(cn))
        {
        }
    }
