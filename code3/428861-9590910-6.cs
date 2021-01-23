    public static IEnumerable<RetrieveActiveMuseumByMuseumID_Result> GetActiveMuseum()
    { 
         return GetData("exec StoredProcedureName @ParameterName", p => 
              {
                 p.Add("@ParameterName", SqlDbTypes.???).Value = ParameterValue;
              }).Select(r => RetrieveActiveMuseumByMuseumID_Result.Create(r));
    }
