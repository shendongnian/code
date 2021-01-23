        protected void Page_Load(object sender, EventArgs e)
        {
             SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
             SqlCommand cmd = new SqlCommand("SELECT Date, Day, Time, Total FROM RSVP WHERE Id = @dummy", conn);
             cmd.Parameters.AddWithValue("@dummy", DropDownList5.SelectedItem.Text);
             
             conn.open();
             var dr = cmd.ExecuteReader();
             if (dr.HasRows == false)
               throw new Exception("No data found!");   
             if (dr.Read())
             {
                Label1.Text = dr[0].ToString();
                Label2.Text = dr[1].ToString();
                Label3.Text = dr[2].ToString();
                Label4.Text = dr[3].ToString();
             }
             conn.close();
         }
