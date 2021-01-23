    public static IEnumerable<RetrieveActiveMuseumByMuseumID_Result> GetActiveMuseum()
    {
         using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MuseumDB"].ConnectionString))
         using (var cmd = new SqlCommand("StoredProcedureName", cn)
         {
              cmd.CommandType = CommandTypes.StoredProcedure;
              //you need to supply some of the information for this line: you didn't include it in your question
              cmd.Parameters.Add("@ParameterName", SqlDbTypes.???).Value = ParameterValue;
              cn.Open();
              using (var rdr = cmd.ExecuteReader())
              {
                   while (rdr.Read())
                   {  //you'll need to implement the static create method I used here
                       yield return new RetrieveActiveMuseumByMuseumID_Result.Create(rdr);
                   }
              }
         }
     }
