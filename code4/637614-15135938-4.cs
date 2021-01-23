    var positions1 = new[] { 9, 10, 11 };
    var positions2 = new[] { 14, 15, 16 };
    var f1Lines = File.ReadLines(path1)
        .Select((l, i) => new { Line = l, Cols = l.Split('\t'), Num = i + 1 })
        .Where(x => x.Cols.Length >= 2);
    var f2Lines = File.ReadLines(path2)
        .Select((l, i) => new { Line = l, Cols = l.Split('\t'), Num = i + 1 })
        .Where(x => x.Cols.Length >= 2);
    var toBeArchived = from i in positions1
                       join f1 in f1Lines on i equals f1.Num
                       join f2 in f2Lines on f1.Cols[1] equals f2.Cols[1]
                       where positions2.Contains(f2.Num)
                       select new { f1, f2 };
    foreach (var toArchive in toBeArchived)
    { 
        // i'm not sure what you want to do with it finally
        // use File.WriteAllLines if you want to create the merged files
    }
