    public class ColumnSeries
    {
        public string type {get; set;}
        //...
    }
    //class level variable
    List<ColumnSeries> columnSeries = null;
    //then create the ColumnSeries list
    columnSeries = (from l in logs
                    group l by l.MonitoringPorfileName into grp
                    select new ColumnSeries
                    {
                       type = "column",
                       name = grp.Key,
                       data = (from h in Hours
                              let gd = grp.Where(x => x.Hours == h)
                              select gd.Sum(x => x.Count)).ToArray()
                    }).ToList();
