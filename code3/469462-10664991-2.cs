    private DataTable GetTableBySPName(string name)
    {
      DataTable dt = null;
      switch (name)
      {
       case "GetDays":
       {
        dt = new GetDatsDTO();
        break;
       }
      }
     return dt;
    }
