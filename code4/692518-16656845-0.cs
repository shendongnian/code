     commandstring = "INSERT INTO tblItUdstyr([HardwareType], [KobsDato], [SerieNr]) " + 
                     "VALUES(@HardwareType, @KobsDato, @SerieNr)";
    using(conn = new SqlConnection(connectionstring))
    using(comm = new SqlCommand(commandstring, conn))
    {
         conn.Open();
         comm.Parameters.Add("@HardwareType", SqlDbType.VarChar);
         comm.Parameters["@HardwareType"].Value = cbHardware.Text.ToString();
         comm.Parameters.Add("@KobsDato", SqlDbType.Date);
         comm.Parameters["@KobsDato"].Value = dtpKobsDato.Value;
         comm.Parameters.Add("@SerieNr", SqlDbType.VarChar);
         comm.Parameters["@SerieNr"].Value = txtSerienr.Text.ToString();
         comm.ExecuteNonQuery();  //This is the call that sends your data to the database
    }
