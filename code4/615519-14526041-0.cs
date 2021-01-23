    int month = 2; // f.e. for february
    var currentCalendar = System.Globalization.CultureInfo.CurrentCulture.Calendar;
    int daysInMonth = currentCalendar.GetDaysInMonth(month);
    DateTime start = new DateTime(DateTime.Now.Year, month, 1);
    DateTime end = new DateTime(DateTime.Now.Year, month, daysInMonth);
    var filteredRows = LeaveDS.Tables["Leave"].AsEnumerable()
        .Where(r => r.Field<DateTime>("LeaveDate").Date >= start
                 && r.Field<DateTime>("LeaveDate").Date <= end );
    // use ToArray for an array, CopyToDataTable for a DataTable etc.
