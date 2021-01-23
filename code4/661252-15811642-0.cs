    //Based on Mark's code, below comes close... but updates still failing
    //Maybe I need to try an earlier version?
    
    String strTeam = "xxx";
    
    String workspaceRef = "/workspace/4914063320";
    String projectRef = "/project/7412041414";
    
    //get user story
    Request reqUserStory = new Request("hierarchicalrequirement");
    reqUserStory.Fetch = new List<string>() { "ObjectID", "Release", "Iteration", "PlanEstimate", "Description", "Tags" };
    
    reqUserStory.Query = new Query("Project", Query.Operator.Equals, projectRef)
        .And(new Query("Name", Query.Operator.Equals, "mystoryname"));
     
    QueryResult queryResultUS = restApi.Query(reqUserStory);
    DynamicJsonObject myUserStory = new DynamicJsonObject();
    myUserStory = queryResultUS.Results.FirstOrDefault();
    if (null != myUserStory)
    {
    //get tags for user story
    	var existingTags = myUserStory["Tags"];
    	if (null != existingTags)
    	{
    		bool bFound = false;
    
    		var tagList = existingTags["_tagsNameArray"];
    		//look for tag
    		foreach (var tag in tagList)
    		{
    			String strValue = tag["Name"];
    			if (strValue == strTeam)
    				bFound = true;
    		}
    
    		if (!bFound)
    		{
    			//replace tags array
    			
    			var targetTagArray = existingTags;
    			var tagList2 = targetTagArray["_tagsNameArray"];
    			tagList2.Add(targetTag);//even if i comment this out, update below fails...
    			targetTagArray["_tagsNameArray"] = tagList2;
    			                
    			DynamicJsonObject toUpdate = new DynamicJsonObject();
    			toUpdate["Tags"] = targetTagArray;
    			long oid = Convert.ToInt64(myUserStory["ObjectID"]);
    			opResultRelease = restApi.Update("hierarchicalrequirement", oid, toUpdate);
    			// Fails with Error: ["Could not read: Could not read referenced object 2"]
    		}
    
    	}
    }
