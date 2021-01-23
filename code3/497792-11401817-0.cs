    private CustomClass[] Test1(string[] serialNumbers) {
      List<CustomClass> list = new List<CustomClass>();
      Parallel.For(0, serialNumber.Length, (i) => {
        DataTable table = new DataTable();
        using (SqlCommand cmd = new SqlCommand("sp_GetData", m_open_conn)) {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("@sn", SqlDbType.Char, 20).Value = serialNumber[i];
          table.Load(cmd.ExecuteReader());
        }
        list.Add(CustomClass.CreateSummary(table));
      });
      return list.ToArray();
    }
