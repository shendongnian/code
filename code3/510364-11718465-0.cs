    var query = tA
        .Where(a => a.cAuthorizedStatus == "Pending")
        .Join(tB, a => a.nGroupCode, b => b.nGroupCode, (a, b) => new 
        { 
            cSubGroupName = a.cSubGroupName, 
            cAddedBy = a.cAddedBy, 
            dAddedOn = a.dAddedOn, 
            cGroupName = b.cGroupName 
        });
