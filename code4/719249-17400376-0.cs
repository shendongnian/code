    protected void button_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand comm = new SqlCommand("SELECT * FROM news
                    Where newstilte LIKE '%@search%'", conn);
                
                cmm.Parameters.AddWithValue("@search",searchbox.text)  ;
                conn.Open();
                SqlDataAdapter reader = comm.ExecuteReader();
                myRepeater.DataSource = reader;
                myRepeater.DataBind();
                reader.Close();
            }
            catch (Exception exception)
            {
                Response.Write(exception.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
