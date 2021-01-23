    var userIds = table.Select(row => row.userid).Distinct();
    var checkTimes = table.Select(row => row.CheckTime).Distinct();
    var pivotTable =
        from userid in userIds
        select new {
            userid,
            attflags = checkTimes.Select(checkTime =>
                table.Where(row => row.userid == userid && row.CheckTime == checkTime)
                     .Select(row => row.attflag)
                     .DefaultIfEmpty("-")
                     .FirstOrDefault())
        };
     Console.WriteLine("userid\t" + String.Join("\t", checkTimes));
     foreach (var pivotRow in pivotTable)
         Console.WriteLine(pivotRow.userid + "\t" + String.Join("\t", pivotRow.attflags));
        
