    private void lgnbtn_Click(object sender, EventArgs e)
        {
            string dummyun = uninput.Text;
            string dummypw = pwinput.Text;
            using(SqlCommand StrQuer = new SqlCommand("SELECT * FROM nurse WHERE n_id=@userid AND n_pw=@password", ConnObject))
            {
               StrQuer.Parameters.AddWithValue("@userid",dummyun);
               StrQuer.Parameters.AddWithValue("@password",dummypw);
             SqlDataReader dr = StrQuer.ExecuteReader(); 
             If(dr.HasRows)
             {
               MessageBox.Show("loginSuccess");    
             }
            else
            {
              //invalid login
            } 
         }   
        }
