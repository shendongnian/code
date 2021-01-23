    SqlCommand AddMed = new SqlCommand("INSERT INTO Medications VALUES(?,?,?)", mcs);
    
    AddMed.Parameters.Add("@Medication", SqlDbType.NVarChar).Value = MedName.Text.ToString();
    AddMed.Parameters.Add("@Dose", SqlDbType.Int).Value = dose;
    AddMed.Parameters.Add("@manufacture", SqlDbType.NVarChar).Value = ManuDB.Text.ToString();
