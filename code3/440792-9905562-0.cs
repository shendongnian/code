    void Main()
    {
    	Dictionary<string, Action> d = new Dictionary<string, Action>()
    	{
    		{"A1", Do1},
    		{"A2", Do2},
    		{"A3", Do3},
    		{"B1", Do4},
    		{"B2", Do5},
    		{"B3", Do6},
    		{"1", Do7},
    		{"2", Do8},
    		{"3", Do9}
    	};
    	var x = "A";
    	var y = "1";
    	var action = x == "A" || x == "B" ? x + y : y;
    	if (d.ContainsKey(action))
    		d[action]();
    }
    
    public void Do1() {}
    public void Do2() {}
    public void Do3() {}
    public void Do4() {}
    public void Do5() {}
    public void Do6() {}
    public void Do7() {}
    public void Do8() {}
    public void Do9() {}
