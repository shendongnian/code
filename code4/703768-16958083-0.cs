    foreach (var name in from c in panel1.Controls.OfType<CheckBox>() where c.Checked select c.Name)
    {
       foreach (TextBox cd in panel1.Controls.OfType<TextBox>().Where(cd => cd.Text != "" && cd.Name == name))
       {
           con3.Open();
           SqlCommand cmd3 = new SqlCommand("insert into.....", con3);
           cmd3.ExecuteNonQuery();
           con3.Close();
        }
    } 
