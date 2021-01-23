	class Program
	{
		DataTable dtIdentificatieRecords = GetTable();
		String checkTimeSpan, check2TimeSpan;
		static void Main(string[] args)
		{
			Program Test = new Program();
			Test.check();
			Test.check2();
			Console.WriteLine("checkTimeSpan: {0}", Test.checkTimeSpan);
			Console.WriteLine("check2TimeSpan: {0}", Test.check2TimeSpan);
			Console.ReadLine();
		}
		/// <summary>
		/// This example method generates a DataTable.
		/// </summary>
		static DataTable GetTable()
		{
			//
			// Here we create a DataTable with four columns.
			//
			DataTable table = new DataTable();
			table.Columns.Add("STAMNRVOL", typeof(string));
			table.Columns.Add("Drug", typeof(string));
			table.Columns.Add("Patient", typeof(string));
			table.Columns.Add("Date", typeof(DateTime));
			//
			// Here we add five DataRows.
			//
			for (int a = 0; a < 999999; a++)
			{
				table.Rows.Add(a%2==0?a.ToString():"", "Indocin", "David", DateTime.Now);
			}
			return table;
		}
		private void check()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			checkStamnr();
			checkStamnr();
			checkStamnr();
			checkStamnr();
			checkStamnr();
			stopwatch.Stop();
			checkTimeSpan = stopwatch.Elapsed.TotalSeconds.ToString();
			stopwatch.Reset();
		}
		private void checkStamnr()
		{
			foreach (DataRow dr in dtIdentificatieRecords.Rows)
			{
				if (dr["STAMNRVOL"] == null || dr["STAMNRVOL"].GetType() == typeof(DBNull) || dr["STAMNRVOL"].Equals(""))
				{
					DatabankFout df = new DatabankFout("Stamnummer is leeg.");
				}
			}
		}
		private void check2()
		{
			System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
			sw.Start();
			foreach (DataRow dr2 in dtIdentificatieRecords.Rows)
			{
				checkStamnr2(dr2);
				checkStamnr2(dr2);
				checkStamnr2(dr2);
				checkStamnr2(dr2);
				checkStamnr2(dr2);
			}
			sw.Stop();
			check2TimeSpan = sw.Elapsed.TotalSeconds.ToString();
			sw.Reset();
		}
		private void checkStamnr2(DataRow dr)
		{
			if (dr["STAMNRVOL"] == null || dr["STAMNRVOL"].GetType() == typeof(DBNull) || dr["STAMNRVOL"].Equals(""))
			{
				DatabankFout df = new DatabankFout("Stamnummer is leeg.");
			}
		}
	}
	public class DatabankFout
	{
		public DatabankFout(string reden, bool rood)
		{
			this.reden = reden;
			this.rood = rood;
		}
		public DatabankFout(string reden)
			: this(reden, false)
		{
		}
		public string reden { get; set; }
		public bool rood { get; set; }
	}
