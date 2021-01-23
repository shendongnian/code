	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	namespace LinqTest
	{
		class LinqProgram
		{
			public class Program
			{
				public int ProgramID { get; set; }
				public string ProgramName { get; set; }
			}
			public class ProgramLocation
			{
				public int ProgramLocationID { get; set; }
				public int ProgramID { get; set; }
				public string ProgramLocationName { get; set; }
			}
			public static List<Program> Programs = new List<Program>();
			public static List<ProgramLocation> ProgramLocations = new List<ProgramLocation>();
			static void Main(string[] args)
			{
				FillTestData();
				var query = from p in Programs
							join pl in ProgramLocations
								on p.ProgramID equals pl.ProgramID into pp
							from pl in pp.DefaultIfEmpty()
							where pl == null
							select p;
				foreach (var r in query)
				{
					Console.WriteLine("{0}: {1}", r.ProgramID, r.ProgramName);
				}
				Console.ReadLine();
			}
			private static void FillTestData()
			{
				var p = new Program()
				{
					ProgramID = Programs.Count + 1,
					ProgramName = "Scary Lesson"
				};
				var pl = new ProgramLocation()
				{
					ProgramLocationID = ProgramLocations.Count + 1,
					ProgramID = p.ProgramID,
					ProgramLocationName = "Haunted House"
				};
				Programs.Add(p);
				ProgramLocations.Add(pl);
				p = new Program()
				{
					ProgramID = Programs.Count + 1,
					ProgramName = "Terrifying Teachings"
				};
				pl = new ProgramLocation()
				{
					ProgramLocationID = ProgramLocations.Count + 1,
					ProgramID = p.ProgramID,
					ProgramLocationName = "Mystical Mansion"
				};
				Programs.Add(p);
				ProgramLocations.Add(pl);
				p = new Program()
				{
					ProgramID = Programs.Count + 1,
					ProgramName = "Unassociated Program"
				};
				Programs.Add(p);
			}
		}
	}
