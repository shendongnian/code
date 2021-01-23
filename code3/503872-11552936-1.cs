    using (SqlConnection con = new SqlConnection(connectionString))
    	{
            string userName = lblUsername.Text;
            con.Open(); 
            var adapter = new SqlDataAdapter("Select ScheduleID, Subject From 
                                     Schedules Where Username = @username", conn);
            adapter.Parameters.Add("@username", SqlDbType.VarChar, 50, userName)
            var dsSched = new DataSet();
            adapter.Fill(dsSched);
            
            cbxSubject.DataSource = dsSched.Tables[0];
            cbxSubject.DisplayMember = "Subject";
            cbxSubject.ValueMember = "ScheduleID";
            cbxSubject.DataBind();
            
        }
