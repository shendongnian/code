    var query = tA
        .Join(tB, a => a.nGroupCode, b => b.nGroupCode, (a, b) => new 
        { 
            cSubGroupName = a.cSubGroupName, 
            cAddedBy = a.cAddedBy, 
            dAddedOn = a.dAddedOn, 
            cGroupName = b.cGroupName,
            cAuthorizedStatus = a.cAuthorizedStatus
        })
        .Where(j => j.cAuthorizedStatus == "Pending")
        .Select(j => new
        { 
            cSubGroupName = j.cSubGroupName, 
            cAddedBy = j.cAddedBy, 
            dAddedOn = j.dAddedOn, 
            cGroupName = j.cGroupName
        });
