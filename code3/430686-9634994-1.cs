    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["chestionar"].ConnectionString);
    string qry="select * from personal,Intrebari where personal.cod_numeric_personal=@cnp AND Intrebari.id_intrebare IN (14,15);
    SqlCommand cmd = new SqlCommand(qry, con);
    cmd.Parameters.AddWithValue("@cnp", Session["sesiune_cnp"]);
    try
    {  
       con.Open();    
       SqlDataReader rdr= cmd.ExecuteReader();
       if(rdr.HasRows)
       {    
            while (rdr.Read())
            {
                lbl1.Text = rdr["Nume"].ToString();
                intrebare6.Text = rdr["Intrebari"].ToString();
                intrebare7.Text = rdr["Intrebari"].ToString();
            }
       }
    }
    catch(SQLException ex)
    {
       lblStatus.Text="An error occured"+ex.Message;
       throw ex;
    }
    finally
    {
       con.Close();
       con.Dispose();
    }
