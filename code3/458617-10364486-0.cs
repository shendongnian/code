    public class DatabaseGateway
    {
      public IList<T> RetrieveSqlAs<T>(string queryString, ITransformer<SqlDataReader, T> rowTransformer)
      {
        var result = new List<T>();
        using (var sqlConn = new SqlConnection(<connection string>))
        using (var sqlCommand = new SqlCommand(queryString, sqlConn))
        {
          var myreader = sqlComm.ExecuteReader();
          while (myreader.Read())
          {
             result.Add(rowTransformer.Transform(myreader));
          }
        }
        return result;
      }
    }
    
    public class MemberRowTransformer : ITransformer<SqlDataReader, string>
    {
      public string Transform(SqlDataReader from)
      {
        from["members"];  // handle null and anything else here
      }
    }
    public interface ITransformer<TFrom, TTo>
    {
      TTo Transform(TFrom)
    }
