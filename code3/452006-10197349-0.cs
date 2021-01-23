    var listOfConditions = new List,int>{50,60,70};
    var tempTable = (from p in dc.Live_Diffs
                                 where listOfConditions.Constains(p.RowNum)
                                 select new CustomResult
                                 {   RowNum = p.RowNum ,
                                     ED1 = p.ED1,
                                     ED2 = p.ED2,
                                     ED3 = p.ED3,
                                     ED4 = p.ED4,
                                     ED5 = p.ED5,
                                     ED6 = p.ED6,
                                     ED7 = p.ED7,
                                     ED8 = p.ED8
                                 }).ToList();
