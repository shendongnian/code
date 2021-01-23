	public Node BuildTree()
	{
		var _1A = new Node() { Id = 1, Name = "A", };
		var _2B = new Node() { Id = 2, Name = "B", };
		var _3C = new Node() { Id = 3, Name = "C", };
		var _4D = new Node() { Id = 4, Name = "D", };
		var _5E = new Node() { Id = 5, Name = "E", };
		var _6F = new Node() { Id = 6, Name = "F", };
		_1A.ChildLocations.Add(_2B);
		_1A.ChildLocations.Add(_3C);
		_1A.ChildLocations.Add(_4D);
		_3C.ChildLocations.Add(_5E);
		_3C.ChildLocations.Add(_6F);
		return _1A;
	}
