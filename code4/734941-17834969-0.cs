    static class ConnectionFactory
    {
     public static SqlConnection Create() {
      return new SqlConnection(GetConnectionStringSomehow());
     }
    }
