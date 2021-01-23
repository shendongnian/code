			const int Max = 100000;
			var rnd = new Random();
			var list1 = Enumerable.Range(1, Max).Select(r => rnd.Next(Max)).ToList();
			var list2 = Enumerable.Range(1, Max).Select(r => rnd.Next(Max)).ToList();
			var list3 = Enumerable.Range(1, Max).Select(r => rnd.Next(Max)).ToList();
			DateTime start;
			start = DateTime.Now;
			var r1 = list1.Zip(list2, (a, b) => new { a, b }).Zip(list3, (ab, c) => new { ab.a, ab.b, c }).ToList();
			var time1 = DateTime.Now - start;
			start = DateTime.Now;
			var r2 = list1.Select((l1, i) => new { a = l1, b = list2[i], c = list3[i] }).ToList();
			var time2 = DateTime.Now - start;
			start = DateTime.Now;
			var r3 = new int[0].Select(i => new { a = 0, b = 0, c = 0 }).ToList();
			//	Easy out-of-bounds prevention not offered in solution #2 (if list2 or list3 have fewer items)
			int max = new int[] { list1.Count, list2.Count, list3.Count }.Max();
			for (int i = 0; i < max; i++)
				r3.Add(new { a = list1[i], b = list2[i], c = list3[i] });
			var time3 = DateTime.Now - start;
			Debug.WriteLine("r1 == r2: {0}", r1.SequenceEqual(r2));
			Debug.WriteLine("r1 == r3: {0}", r1.SequenceEqual(r3));
			Debug.WriteLine("time1 {0}", time1);
			Debug.WriteLine("time2 {0}", time2);
			Debug.WriteLine("time3 {0}", time3);
