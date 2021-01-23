    private void btnInsert_Click(object sender, EventArgs e)
    {
      OleDbCommand cmd = new OleDbCommand(@"INSERT INTO Table1
                                            (ID, AgeGroup, Gender, CriminalOffence)   
                                      VALUES(@ID, @AgeGroup, @Gender, @CriminalOffence)", myCon);
      cmd.CommandType = CommandType.Text;
    
      cmd.Parameters.AddWithValue("@ID", txtID.Text);
      cmd.Parameters.AddWithValue("@AgeGroup", cbAG.Text);
      cmd.Parameters.AddWithValue("@Gender", cbGender.Text);
      cmd.Parameters.AddWithValue("@CriminalOffence", ((rBYes.Checked)? "Yes":"No"));
      myCon.Open();
      cmd.ExecuteNonQuery();
      myCon.Close(); 
    }
