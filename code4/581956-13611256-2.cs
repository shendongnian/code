     public const string Quote = "\"";
     public static void EmitCsvLine(TextWriter report, IList<string> values)
        {
            List<string> csv = new List<string>(values.Count);
 
            for (var z = 0; z < values.Count; z += 1)
            {
                csv.Add(Quote + values[z].Replace(Quote, Quote + Quote) + Quote);
            }
 
            string line = String.Join(",", csv);
 
            report.WriteLine(line);
        }
