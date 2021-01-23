            void showuser()
        {
            string Employeename = (string)(Session["UserName"]);
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand mycomm=new SqlCommand ("SELECT * FROM [ExpTab] WHERE UserID = @username",con);
            mycomm.CommandType=CommandType.StoredProcedure;
            mycomm.Parameters.Add("@username", SqlDbType.VarChar).Value = ;
            SqlDataAdapter showdata = new SqlDataAdapter(mycomm);
            DataSet ds = new DataSet();
            showdata.Fill(ds);
            txtEmployeename.Text = ds.Tables[0].Rows[0]["Emp_Username"].ToString();
            txtBranchName.Text = ds.Tables[0].Rows[0]["Branch_BranchName"].ToString();
            txtApprvdby.Text = ds.Tables[0].Rows[0]["Approval_ApprovedBY"].ToString();
            binddropdownlist();
            con.Close();           
        }
