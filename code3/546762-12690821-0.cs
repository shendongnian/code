    public void BindData(System.Data.DataTable t)
    {
       GridView1.DataSource = t;
       if(t.Rows.Count > 0)
       {
          FirstNameTextBox.Text = Convert.ToString(t.Rows[0]["FirstName"])
       }
    }
