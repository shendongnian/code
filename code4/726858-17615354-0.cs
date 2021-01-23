			var l1 = new List<int>{1, 2, 3, 4, 5};
			var masterList = new List<List<int>>();
			masterList.Add(l1);
			var l2 = new List<int>();
			l2.AddRange(l1);
			l2.RemoveAt(0);
			masterList.Add(l2);
			MessageBox.Show(masterList[0].Count.ToString() + " and " + masterList[1].Count.ToString());
