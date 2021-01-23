    // Eagerly read the "inner" file
    var lines2 = File.ReadAllLines(dbFilePath + "newdbcontents.txt");
    var query = from line1 in File.ReadLines("newDataPath + "HolidayList1.txt")
                from line2 in lines2
                where line2.Contains(line1)
                select line1;
    var commonLines = query.ToList();
                select line1;
