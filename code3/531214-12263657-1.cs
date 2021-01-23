    var tcaseGroups = tbl.AsEnumerable()
        .GroupBy(r => r.Field<String>("TestCaseID"))
        .Select(g => new
        {
            Testcase = g.Key,
            Count = g.Count(),
            CaseInfo = g.GroupBy(r => r.Field<String>("Status"))
                         .Select(gStatus => new
                         {
                             Status = gStatus.Key,
                             Count = gStatus.Count()
                         })
        });
    
    // output the result
    foreach (var x in tcaseGroups)
        Console.WriteLine("Testcase:{0}, Count:{1} Results:[{2}]", x.Testcase, x.Count
            , String.Join(",", x.CaseInfo.Select(xx => 
                String.Format("Status:{0} Count:{1}", xx.Status, xx.Count))));
