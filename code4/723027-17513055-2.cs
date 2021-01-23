    int typdop=1; 
    if(rb_a.Checked) typdop=0; 
    string cmdText = "INSERT INTO zajezd(typdop)values(@typdop)"; 
    SqlCommand prikaz = new SqlCommand(cmdText,spojeni);
    prikaz.Parameters.AddWithValue("typdop", typdop);
    spojeni.Open();
    prikaz.ExecuteNonQuery();
    ....
