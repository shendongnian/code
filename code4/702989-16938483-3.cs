    foreach (CheckBox c in panel1.Controls.OfType<CheckBox>())
    {
        if (c.Checked)
        {
            foreach(TextBox cd in panel1.Controls.OfType<TextBox>())
            {
                string val = cd.Text;
                if (val != "" && cd.Name == name)
                {
                  con3.Open();
                  SqlCommand cmd3 = new SqlCommand("insert into ....", con3)
                  cmd3.ExecuteNonQuery();
                  con3.Close();
                }
            }
        }
    }
