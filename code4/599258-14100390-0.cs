    using (var conn = new SqlConnection("Your ConnectionString comes here"))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText =
        @"INSERT INTO Ph_Tbl_Contacts 
              (Contact_Name, 
               Contact_LName, 
               Contact_Company, 
               Contact_Email, 
               Contact_Tel, 
               Contact_Mobile, 
               Contact_CardImage, 
               Is_Public, 
               User_ID, 
               Save_Date)
          VALUES 
              (@Contact_Name, 
               @Contact_LName, 
               @Contact_Company, 
               @Contact_Email, 
               @Contact_Tel, 
               @Contact_Mobile, 
               @Contact_CardImage, 
               @Is_Public, 
               @User_ID, 
               @Save_Date)
        ";
        cmd.Parameters.AddWithValue("@Contact_Name", Txt_Name.Text);
        cmd.Parameters.AddWithValue("@Contact_LName", Txt_LastName.Text);
        cmd.Parameters.AddWithValue("@Contact_Company", Txt_CompanyName.Text);
        cmd.Parameters.AddWithValue("@Contact_Email", Txt_Mail.Text);
        cmd.Parameters.AddWithValue("@Contact_Tel", Txt_Telephone.Text);
        cmd.Parameters.AddWithValue("@Contact_Mobile", Txt_Mobile.Text);
        cmd.Parameters.AddWithValue("@Contact_CardImage", IMAGEbYTE);
        cmd.Parameters.AddWithValue("@Is_Public", CheckValue);
        cmd.Parameters.AddWithValue("@User_ID", Session["User_ID"]);
        cmd.Parameters.AddWithValue("@Save_Date", DateStr); 
        cmd.ExecuteNonQuery();
    }
