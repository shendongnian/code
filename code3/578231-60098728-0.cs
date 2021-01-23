            iFilter.MyDate1 = DateTime.Today;  // or DateTime.MinValue
			// GET 
            var tempQuery = ctx.MyTable.AsQueryable();
            if (iFilter.MyDate1 != DateTime.MinValue)
            {
                TimeSpan temp24h = new TimeSpan(23,59,59);
                DateTime tempEndMyDate1 = iFilter.MyDate1.Add(temp24h);
				
				// DO not change the code below, you need 2 date variables...
                tempQuery = tempQuery.Where(w => w.MyDate2 >= iFilter.MyDate1
                                              && w.MyDate2 <= tempEndMyDate1);
            }
			List<MyTable> returnObject = tempQuery.ToList();
