    var state = new QueryState
    {
       CloudTable = tableSymmetricKeys,
       //set everything else
    }
    
    var result = tableSymmetricKeys.BeginExecuteQuerySegmented(query, token, opt, ctx,asyncCallback, state);
