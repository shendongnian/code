    SqlCommand prikaz = new SqlCommand("INSERT INTO klient(name,surname) values(@kname,@ksurname)", spojeni);
    prikaz.Parameters.AddWithValue("@kname", kname.Text);
    prikaz.Parameters.AddWithValue("@ksurname", ksurname.Text);
    spojeni.Open();
    prikaz.ExecuteNonQuery();
    ......
