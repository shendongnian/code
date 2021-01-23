    comd.CommandText = "SELECT * FROM MyTable";
    
    con.Open();
    SqlDataReader reader = comd.ExecuteReader();
    while (reader.Read())
    {
    	City myData = new City();
    	myData.State = reader["State"].ToString().Trim();
    	myData.Cities = reader["Cities"].ToString().Trim();
    	giveData.Add(myData);
    }  
    int count = 1;
    Dictionary<string, TreeNode> result = new Dictionary<string, TreeNode>();
    foreach (City myData in giveData) 
    {
    	if (result.ContainsKey(myData.State ))
    	{
    		result[myData.State].children.Add(new TreeNode() {
    			id = count++,
    			name = myData.Cities,
    			leaf = true
    		});
    	}
    	else
    	{
    		result.add(giveData.State, new TreeNode() {
    			id = count++,
    			name = myData.State,
    			leaf = false,
    			children = new List<TreeNode>()
    		});
    	}
    }
    
    return JsonConvert.SerializeObject(result.Values);
