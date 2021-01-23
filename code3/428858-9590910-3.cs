    public static IEnumerable<RetrieveActiveMuseumByMuseumID_Result> GetActiveMuseum()
    { 
         return GetData("exec StoredProcedureName @ParameterName", RetrieveActiveMuseumByMuseumID_Result.Create, p => 
              {
                 p.Add("@ParameterName", SqlDbTypes.???).Value = ParameterValue;
              });
    }
