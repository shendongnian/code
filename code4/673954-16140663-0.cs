     public DataTable FilterURLS(DataTable urllist)
     {
          return
               (from urlrow in urllist.Rows.OfType<DataRow>()
                group urlrow by urlrow.Field<string>("Host") into g
                select g
                .OrderBy(r => r.Field<int>("ID"))
                .First()).CopyToDataTable();
      }
