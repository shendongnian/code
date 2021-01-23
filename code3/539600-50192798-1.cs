    void Fillcombobox()
    {
        
        con.Open();
        cmd = new SqlCommand("select ID From Employees",con);
        Sdr = cmd.ExecuteReader();
        while (Sdr.Read())
        {
            for (int i = 0; i < Sdr.FieldCount; i++)
            {
               comboID.Items.Add( Sdr.GetString(i));
            }
        }
        Sdr.Close();
        con.Close();
    }
