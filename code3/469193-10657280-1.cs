    try 
    { 
        myConnection.Open(); 
        SqlCommand myCommand2 = new SqlCommand("SELECT * FROM PatientDataFields where  PatientID='" + x + "'", myConnection); 
        SqlDataReader rdr = myCommand2.ExecuteReader(); 
    
        Form2 form2 = new Form2(); 
        form2.Show();
        form2.Race.SelectionMode = SelectionMode.MultiSimple;
        while (rdr.Read()) 
        {
            string item = rdr["Race"].ToString();
            if (form2.Race.FindString(item) != -1)
                form2.Race.SelectedItem = item;
            else
                form2.Race.Items.Add(item);
        } 
    }
