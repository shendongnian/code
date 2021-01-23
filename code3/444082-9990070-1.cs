      static int Sum_ForEach_ByColumn_Field(LogParser pglp)
      {
        var column = pglp.PGLStat_Table.Columns["count"];
        int totalcount = 0;
        foreach (DataRow dr in pglp.PGLStat_Table.Rows)
        {
          totalcount += dr.Field<int>(column);
        }
        return totalcount;
      }
      static int Sum_ForEach_ByName_Convert(LogParser pglp)
      {
        int totalcount = 0;
        foreach (DataRow dr in pglp.PGLStat_Table.Rows)
        {
          int c = Convert.ToInt32(dr["count"].ToString());
          totalcount = totalcount + c;
        }
        return totalcount;
      }
      static int Sum_Linq(LogParser pglp)
      {
        var column = pglp.PGLStat_Table.Columns["count"];
        return pglp.PGLStat_Table.Rows.Cast<DataRow>().Sum(row => (int)row[column]);
      }
        var data = GenerateData();
        Sum(data);
        Sum_Linq2(data);
        var count = 3;
        foreach (var info in new[]
          {
            new {Name = "for/each, by column, (int)", Method = (Func<LogParser, int>)Sum},
            new {Name = "for/each, by column, Field<int>", Method = (Func<LogParser, int>)Sum_ForEach_ByColumn_Field},
            new {Name = "for/each, by name, Convert.ToInt", Method = (Func<LogParser, int>)Sum_ForEach_ByName_Convert},
            new {Name = "linq, cast<DataRow>, by column, (int)", Method = (Func<LogParser, int>)Sum_Linq},
          })
        {
          var watch = new Stopwatch();
          for (var i = 0; i < count; ++i)
          {
            watch.Start();
            var sum = info.Method(data);
            watch.Stop();
          }
          Console.WriteLine("{0}, {1}", TimeSpan.FromTicks(watch.Elapsed.Ticks / count), info.Name);
        }
