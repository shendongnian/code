    //Check if the route was correctly followed
    if (currentRoute != null)
    {
        var gatesInOrder = 0;
        for(var i=0; i<_assetReads.Length; i++)
        {
           if(_assetReads[i].ReadPointLocationId == currentRoute[gatesInOrder])
              //gate crossed in order; increment to next gate
              gatesInOrder++;           
        }
        //if we didn't get to the end of the route, send a notification
        if(gatesInOrder != currentRoute.Length)
        {
           ///////////////////////
           //Send notification
           ///////////////////////
        }
    }
