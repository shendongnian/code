        var stage1List = new List<dynamic>();
        var parOpt = new System.Threading.Tasks.ParallelOptions() { MaxDegreeOfParallelism = 30 };
        System.Threading.Tasks.Parallel.ForEach(slowList, parOpt, slowObj =>
        {
            stage1List.Add(new { Obj = slowObj, Value = slowObj.GetSlowValue() });
        });
        var stage2List = stage1List.OrderBy(p => p.Value).Select(p => p.Obj);
