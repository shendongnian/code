    private void button1_Click(object sender, EventArgs e)
    {
        string str = "Server=.\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;";
        using( SqlConnection con = new SqlConnection(str)){
                                try{
                                    con.Open();
                                    string qry = "insert into SubjectMaster (SubjectName) values (@TxtSubjectName)";
                                    SqlCommand cmd = new SqlCommand(qry, con);
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Parameters.AddWithValue("@TxtSubjectName", TxtSubjectName.Text);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Added Successfully!!");
                                   }
                              catch{
                                    MessageBox.Show("connection is failed!!");
                                   }
                                                           }
    }
