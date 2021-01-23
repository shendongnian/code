    var entriesOnTheDate = dbContext
        .EntriesWithDateTimeField
        .Where(item => SqlFunctions.DatePart("Year", item.DateTimeField) == 2012
                    && SqlFunctions.DatePart("Month", item.DateTimeField) == 8
                    && SqlFunctions.DatePart("Day", item.DateTimeField) == 12);
