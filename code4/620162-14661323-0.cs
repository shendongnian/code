            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("dt", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("num", typeof(int)));
            dt.Rows.Add(new DateTime(2010, 1, 1), 5);
            dt.Rows.Add(new DateTime(2010, 1, 2), 4);
            dt.Rows.Add(new DateTime(2010, 1, 3), 2);
            dt.Rows.Add(new DateTime(2010, 1, 5), 6);
            dt.Rows.Add(new DateTime(2010, 1, 8), 6);
            dt.Rows.Add(new DateTime(2010, 1, 9), 6);
            dt.Rows.Add(new DateTime(2010, 1, 12), 6);
            DateTime minDT = dt.Rows.Cast<DataRow>().Min(row => (DateTime)row["dt"]);
            DateTime maxDT = dt.Rows.Cast<DataRow>().Max(row => (DateTime)row["dt"]);
            List<DateTime> dts = new List<DateTime>();
            DateTime DT = minDT;
            while (DT <= maxDT)
            {
                dts.Add(DT);
                DT = DT.AddDays(1);
            }
            var DTsNotInTable = dts.Except(dt.Rows.Cast<DataRow>().Select(row => (DateTime)row["dt"]));
            foreach (DateTime dateTime in DTsNotInTable)
                dt.Rows.Add(dateTime, 0);
            var ordered = dt.Rows.Cast<DataRow>().OrderBy(row => (DateTime)row["dt"]);
            DataTable dt2 = ordered.CopyToDataTable();
