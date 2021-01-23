		static void Main()
		{
			var strList1 = new[] { "TDC1ABF", "TDC1ABI", "TDC1ABO" };
			var strList2 = new[] { "TDC2ABF", "TDC2ABI", "TDC2ABO" };
			var strList3 = new[] { "TDC3ABF", "TDC3ABO", "TDC3ABI" };
			var allItems = strList1.Concat(strList2).Concat(strList3);
			var abfItems = allItems.Where(item => item.ToUpper().EndsWith("ABF"))
				.OrderBy(item => item);
			var abiItems = allItems.Where(item => item.ToUpper().EndsWith("ABI"))
				.OrderBy(item => item);
			var aboItems = allItems.Where(item => item.ToUpper().EndsWith("ABO"))
				.OrderBy(item => item);
		}
