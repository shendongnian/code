    List<TableInfo> tables = dtTemplates.Rows.AsEnumerable()
        .Select(t => new TableInfo
            {
                FileName = row["FileName"],
                Date = row["Date"],
                Time = row["Time"],
                Info = row["Info"]
            })
        .ToList();
   
        close_Connection();
        return View(tables);
