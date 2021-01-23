	var list = new List<int>();
	if (saljes == "on")
		list.Add(1);
	if (kopes == "on")
		list.Add(2);
	if (bytes == "on")
		list.Add(3);
	if (erbjudes == "on")
		list.Add(4);
    var searchResult = db.Ads.Where(s => list.Contains(s.Type));
