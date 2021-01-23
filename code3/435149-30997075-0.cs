    using (SqlConnection connection = new SqlConnection("SqlConnection"))
    {
            connection.Open();
            SqlCommand SqlCommandDD = new SqlCommand("SELECT FirstName + ' ' + LastName AS 'TextField', Contact_ID, Email, PhoneNumber, CompanyID FROM ContactPerson");
            SqlCommandDD.Connection = connection;
    
            DropDownList2.DataSource = SqlCommandDD.ExecuteReader();
            DropDownList2.DataValueField = "Contact_ID";
            DropDownList2.DataTextField = "TextField";
            DropDownList2.DataBind();
    }
