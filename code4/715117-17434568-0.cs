    protected void LoadProfile()
    {
            conn = new SqlConnection(connString);
            cmdProfile = new SqlCommand("SELECT Name, Father, Gender, UserName, City, Country, Department, Year, Degree, JobTittle, Organization, JobCity, JobCountry, JobTittle FROM UserProfile WHERE UserName=:UserName", conn);
            cmdProfile.Parameters.AddWithValue("UserName", userName);
            conn.Open();
            reader = cmdProfile.ExecuteReader();
            if (reader.Read())
            {
                labelName.Text = reader["Name"].ToString();
                txtBoxFather.Text = reader["Father"].ToString();
                TextBoxGender.Text = reader["Gender"].ToString();
                TextBoxAge.Text = "";
                TextBoxCity.Text = reader["City"].ToString();
                TextBoxCountry.Text = reader["Country"].ToString();
                TextBoxDepartment.Text = reader["Department"].ToString();
                TextBoxDegree.Text = reader["Degree"].ToString();
                TextBoxYear.Text = reader["Year"].ToString();
                TextBoxJobTittle.Text = reader["JobTittle"].ToString();
                TextBoxJobCity.Text = reader["JobCity"].ToString();
                TextBoxJobCountry.Text = reader["JobCountry"].ToString();
                TextBoxOrganization.Text = reader["Organization"].ToString();
            }
            conn.Close();
        } 
