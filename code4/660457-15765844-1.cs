	var columns = DT2.Columns.Cast<DataColumn>().Skip(5);
	DT2.AsEnumerable()
	.Where(r =>
		columns
			.Where(c =>
				r[c] != DBNull.Value &&
				r[c] is double &&
				(r[c] as double) > 0))
	.Average(r =>
		columns.Select(c =>
			r[c] as double))
