    var acceptMode = false;
    var groupCount = 0;
    var groups = data.GroupBy(i => {
        if (acceptMode && rejectPredicate(i)) {
    	    acceptMode = false;
    	    ++groupCount;
    	}
    	else if (!acceptMode && acceptPredicate(i)) {
    	    acceptMode = true;
    	    ++groupCount;
        }
        return groupCount;
    });
