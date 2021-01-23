    string s = DateTime.Now.ToString(CultureInfo.CurrentCulture.DateTimeFormat.SortableDateTimePattern);
    DateTime d = DateTime.Parse(s);
    Console.WriteLine(s);
    Console.WriteLine(d);
    Console.WriteLine();
    s = DateTime.Now.ToString(CultureInfo.CurrentCulture.DateTimeFormat.UniversalSortableDateTimePattern);
    d = DateTime.Parse(s);
    Console.WriteLine(s);
    Console.WriteLine(d);
