			List<int> list2 = new List<int>(new[] { 1, 2, 3, 5, 6 }); // missing: 0 and 4 
			List<int> list1 = new List<int>(new[] { 0, 1, 2, 3, 4, 5, 6 });
			// find items in list 2 notin 1
			var exceptions = list1.Except(list2);
			// or are you really wanting to do a union? (unique numbers in both arrays)
			var uniquenumberlist = list1.Union(list2);
			// or are you wanting to find common numbers in both arrays
			var commonnumberslist = list1.Intersect(list2);
