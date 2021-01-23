	var columns = DT2.Columns.Cast<DataColumn>().Skip(5);
	var rows = DT2.AsEnumerable();
	
	IEnumerable<double> rowAverages =
		  rows
			.Select(r =>
				columns
					.Where(c =>
						r[c] != DBNull.Value &&
						r[c] is double &&
						((double)r[c]) > 0)
					.Select(c =>
						(double)r[c]))
			.Select(r =>
				r.Any() ? r.Average() : 0);
	
	IEnumerable<double> columnAverages =
		  columns
		  	.Select(c =>
				rows.Where(r =>
				  		r[c] != DBNull.Value &&
						r[c] is double &&
						((double)r[c]) > 0)
					.Select(r => (double)r[c]))
			.Select(c => c.Any() ? c.Average() : 0);
