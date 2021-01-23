    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    
    namespace ReportAnalysis {
	static class Program {
		static void Main() {
			//lets run the analysis for Nov, 2012
			//First, read in all report files, and store relevant lines
			var reportInfo = ReportAnalyzer.ReadFiles(2012, 11);
			//Now analyze all files at once
			ReportAnalyzer.RunAnalysis(reportInfo);
		}
	}
	class ReportAnalyzer {
		struct ReportFile {
			public string Path;
			public DateTime Date;
			public List<string> Lines;
		}
		public static IList<ReportFile> ReadFiles(int year, int month) {
			//Put names of files here.
			string[] fileNames = new string[] { "{0:YYYYMMDD}----1234D.dat", "{0:YYYYMMDD}----5678D.dat" };
			DateTime dateStart = new DateTime(year, month, 1); //start of month
			DateTime dateEnd = dateStart.AddMonths(1); //start of NEXT month (i.e. 1 day past end of this month)
			var reportList = new List<ReportFile>();
			DateTime date = dateStart;
			while (date < dateEnd) {  //we don't actually get to dateEnd, just the day before it.
				foreach (var fileTemplate in fileNames) {
					//insert the date in YYYYMMDD format
					var file = string.Format(fileTemplate, date);
					if (File.Exists(file)) {
						var report = new ReportFile() {
							Date = date,
							Path = file,
							Lines = GetReportLines(file)
						};
						reportList.Add(report);
					}
				}
				//now jump to next day
				date = date.AddDays(1);
			}
			return reportList;
		}
		private static List<string> GetReportLines(string file) {
			var lines = new List<string>();
			try {
				using (StreamReader reader = new StreamReader(file)) {
					while (!reader.EndOfStream) {
						var line = reader.ReadLine();
						if (true /* insert criteria */)
							lines.Add(line);
					}
				}
			} catch (Exception ex) {
				//log the error however you see fit
				lines.Add(string.Format("ERROR Could not open report file {0}: {1}", file, ex.Message));
			}
			return lines;
		}
		public static void RunAnalysis(IList<ReportFile> reports) {
			foreach (var r in reports) {
				//Do whatever analysis you need
				Console.WriteLine(r.Date);
				Console.WriteLine(r.Path);
				foreach (var line in r.Lines)
					Console.WriteLine(line);
			}
		}
	}
    }
