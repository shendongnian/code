    public List<T> Get() {
      var list = new List<T>;
      using (var cmd = new SqlCommand(SP_GET, m_openConn)) {
        cmd.CommandType = CommandType.StoredProcedure;
        using (var r = cmd.ExecuteReader()) {
          while (r.Read()) {
            list.Add(FillDataRecord(r));
          }
        }
        cmd.Connection.Close();
      }
      return list;
    }
    ....
    public static List<Buyer> GetBuyerList() {
        return one.Get();
    }
