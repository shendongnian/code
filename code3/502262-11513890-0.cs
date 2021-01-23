    var groupCounter = 0;
    int? prevA = null;
    collection
        .Select(item => { 
            var groupId = item.A == prevA ? groupCounter : ++groupCounter; 
            prevA = item.A;
            return new { groupId, item.A, item.B }; 
        })
        .GroupBy(item => item.groupId)
        .Select(grp => new { A = grp.First().A, Bs = grp.Select(g => g.B) });
