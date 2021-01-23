	var columns = DT2.Columns.Cast<DataColumn>().Skip(5);
	DT2.AsEnumerable()
	.Select(r =>
		columns
			.Where(c =>
				r[c] != DBNull.Value &&
				r[c] is double &&
				((double)r[c]) > 0)
			.Select(c =>
				(double)r[c]))
	.Select(r =>
		r.Average());
