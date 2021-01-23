    foreach (CheckBox c in panel1.Controls.OfType<CheckBox>())
    {
        if (c.Checked && c.Name == name)
        {
            string val = cd.Text;
            if (val != "")
            {
                  con3.Open();
                  SqlCommand cmd3 = new SqlCommand("insert into ....", con3)
                  cmd3.ExecuteNonQuery();
                  con3.Close();
            }
        }
    }
