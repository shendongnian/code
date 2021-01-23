    using (SqlConnection connection =  new SqlConnection("Data Source=localhost;Initial Catalog=LoginScreen;Integrated Security=True"))
    {
        SqlCommand command =
        new SqlCommand("select * from Pending_Tasks WHERE CustomerId=...", connection);
        connection.Open();
    
        SqlDataReader read= command.ExecuteReader();
    
        while (read.Read())
        {
            CustID.Text = (read["Customer_ID"].ToString());
            CustName.Text = (read["Customer_Name"].ToString());
            Add1.Text = (read["Address_1"].ToString());
            Add2.Text = (read["Address_2"].ToString());
            PostBox.Text = (read["Postcode"].ToString());
            PassBox.Text = (read["Password"].ToString());
            DatBox.Text = (read["Data_Important"].ToString());
            LanNumb.Text = (read["Landline"].ToString());
            MobNumber.Text = (read["Mobile"].ToString());
            FaultRep.Text = (read["Fault_Report"].ToString());
        }
        read.Close();
    }
