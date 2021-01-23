	foreach (DataRow row in dt.Rows)
	{
		DateTime d = row.Field<DateTime>("Time");
		row["Time"] = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, 0);
        // or use "tricks" like this
        // row["Time"] = d.AddTicks(-(d.Ticks % TimeSpan.TicksPerMinute));
	}
	foreach(DataRow r in new DataView(dt).ToTable(true).Rows)
		Console.WriteLine(r["Time"]);
