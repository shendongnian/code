    string connetionString = "YOUR_CONSTR" ;
    string updStmt = "UPDATE Quantity set Lamp_pro4=@lamp_pro4,Lamp_pro5=@Lamp_pro5,AC_Profile5=@ac_profile5 " + 
                     "where Locations=@locName";
    using (SqlConnection cnn = new SqlConnection(connetionString))
    {
      cnn.Open();
      SqlCommand updCmd = new SqlCommand(updStmt , cnn);
      
      // use sqlParameters to prevent sql injection!
      updCmd.Parameters.AddWithValue("@lamp_pro4", txt1.Text);
      
      // or define dataType if necessary
      SqlParameter p1 = new SqlParameter();
      p1.ParameterName = "@Lamp_pro5";
      p1.SqlDbType = SqlDbType.Int;
      p1.Value = txt2.Text;
      updCmd.Parameters.Add(p1);
      // demo code must be adapted!! (correct paramNames, textbox names, add missing params ...)
      int affectedRows = updCmd.ExecuteNonQuery();
      Debug.WriteLine(affectedRows + " rows updated!");
    }
