    var positions = new[] { 9, 10, 11 };
    var toBeArchived = from i in positions
                       join f1 in f1Lines on i equals f1.Num
                       join f2 in f2Lines on f1.Num equals f2.Num
                       where f1.Cols.Length >= 2 && f2.Cols.Length >= 2
                       && f1.Cols[1] == f2.Cols[1]
                       select new { f1, f2 };
    foreach (var toArchive in toBeArchived)
    { 
        // i'm not sure what you want to do with it finally
        // use File.WriteAllLines if you want to create the merged files
    }
