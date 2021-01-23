    public void SelectDisPatient(FrmVIRGO frm)
    {
       int count =  Count();
       string query = "SELECT id_pasien FROM tb_patient_information ";
       if (this.OpenConnection() == true)
       { //Create Command
          MySqlCommand cmd = new MySqlCommand(query, connection);
          //Create a data reader and Execute the command
          MySqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
          if (dataReader.HasRows)
          {
             for (int index = 0; index < count ; index++)
             dataReader.Read();
             frm.tbName.Text = dataReader[0].ToString(); 
          } 
          //close Data Reader
          dataReader.Close();
    
          //close Connection
          this.CloseConnection();
    
        }
     }
