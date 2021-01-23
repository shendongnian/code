    public ActionResult DownloadAsCsv(DateTime? start, DateTime? finish)
    {
        // I guess you would use your SearchInspections instead of the following
        // but don't understand it well enough to be sure:
    
        IEnumerable<MyRowClass> rows = GetRelevantRows(start, finish);
    
        StringBuilder csv = new StringBuilder();
        foreach (MyRowClass row in rows)
        {
            // Take care to properly escape cells with embedded " or ,
            // The following is simplified by not doing that for brevity:
            csv.Append(row.PropertyA).Append(',').Append(row.PropertyB);
            csv.AppendLine();
        }
    
        var data = Encoding.UTF8.GetBytes(csv.ToString());
        string filename = "YourDesiredFileName.csv";
        return File(data, "text/csv", filename);
    }
