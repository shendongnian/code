    private void PopulateFields()
    {
      using(SqlConnection con1 = new SqlConnection("Data Source=USER-PC;Initial Catalog=webservice_database;Integrated Security=True"))
      {
        DataTable dt = new DataTable();
        con1.Open();
        SqlDataReader myReader = null;  
        SqlCommand myCommand = new SqlCommand("select * from customer_registration where username='" + Session["username"] + "'", con1);
    
        myReader = myCommand.ExecuteReader();
    
        while (myReader.Read())
        {
            TextBoxPassword.Text = (myReader["password"].ToString());
            TextBoxRPassword.Text = (myReader["retypepassword"].ToString());
            DropDownListGender.SelectedItem.Text = (myReader["gender"].ToString());
            DropDownListMonth.Text = (myReader["birth"].ToString());
            DropDownListYear.Text = (myReader["birth"].ToString());
            TextBoxAddress.Text = (myReader["address"].ToString());
            TextBoxCity.Text = (myReader["city"].ToString());
            DropDownListCountry.SelectedItem.Text = (myReader["country"].ToString());
            TextBoxPostcode.Text = (myReader["postcode"].ToString());
            TextBoxEmail.Text = (myReader["email"].ToString());
            TextBoxCarno.Text = (myReader["carno"].ToString());
        }
        con1.Close();
      }//end using
    }
