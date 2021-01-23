    try
        {
            spojeni.Close();
            SqlCommand sc2 = new SqlCommand("SELECT SUM(castka) AS sumcastka FROM kliplat WHERE akce='" + zakce.Text + "' AND rocnik='" + rocnik + "'", spojeni);
            spojeni.Open();
            object obj = sc2.ExecuteScalar();
            int vysledek2 = obj == null ? 0  : Convert.ToInt32(obj);
            if(vysledek2 > 0){
              SqlCommand sc3 = new SqlCommand("UPDATE zajezd SET s_prijmy=@s_prijmy WHERE akce='" + zakce.Text + "' AND rocnik='" + rocnik + "'", spojeni);
              spojeni.Close();
              sc3.Parameters.AddWithValue("@s_prijmy", vysledek2);
              spojeni.Open();
              sc3.ExecuteNonQuery();
            }
        }
    //....
