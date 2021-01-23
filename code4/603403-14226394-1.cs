	foreach(var id1 in ListAll.Select(x => x.ID).Distinct()) {
		foreach(var id2 in ListAll.Where(x => x.ID==id1).Select(x => x.Secondary_ID).Distinct()) {
			var s=new StringBuilder();
			foreach(var i in ListAll.Where(x => x.ID==id1).Where(x => x.Secondary_ID==id2)) {
				s.Append(String.Format("{0} : {1}", i.Text, i.Number));
			}
			Final.Add(id2, s.ToString());
		}
	}
