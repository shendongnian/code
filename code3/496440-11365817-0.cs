        var myGroup1 = new MyGroup();
		myGroup1.Items = Enumerable.Range (1,3).Select (x=> new MyItem {Val=x}).ToArray();
		var myGroup2 = new MyGroup();
		myGroup2.Items = Enumerable.Range (1,4).Select (x=> new MyItem {Val=x}).ToArray();
		var myGroup3 = new MyGroup();
		myGroup3.Items = Enumerable.Range (3,5).Select (x=> new MyItem {Val=x}).ToArray();
		
		
		var groupList = new List<MyGroup>();
		groupList.Add(myGroup1);
		groupList.Add(myGroup2);
		groupList.Add(myGroup3);
		
		var filterGroups = groupList.Select ( x=>new {Group=x, Min=x.Items.Select( y=> y.Val).Min()}).GroupBy (x=>x.Min).OrderBy (x=>x.Key).Take(1).SelectMany (x=> x).Select (x=>x.Group);
