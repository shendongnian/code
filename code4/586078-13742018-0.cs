        SqlDataReader sdrDatanew = null;
        string strnew;
        string connectionString = WebConfigurationManager.ConnectionStrings["Gen_LicConnectionString"].ConnectionString;
        SqlConnection connew = new SqlConnection(connectionString);
        connew.Open();
        strnew = "select User_Type from User_Details where User_Type='" + ddlUserSel.SelectedItem.Value + "' AND LoginID = '" + txtUserName.Text + "' AND Password = '" + txtPassword.Text + "'";
        SqlCommand sqlCommnew = new SqlCommand(strnew, connew);
        sdrDatanew = sqlCommnew.ExecuteReader();
       
        int userType = 0;
        if (sdrDatanew.HasRows)
        {
            if (sdrDatanew.Read())
            {
                userType = Convert.ToInt32(sdrDatanew["User_Type"].ToString());
            }
        }
        switch (userType)
        {
            case 0:
                Response.Redirect("Lic_Gen.aspx");
                break;
            case 1:
                Response.Redirect("Cust_Page.aspx");
                break;
            default:
                Console.WriteLine("Invalid User/Password");
                Console.ReadLine();
                break;
        }
        connew.Close();
