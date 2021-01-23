    public static string ReadLines(StreamReader input)
    {
        string line;
        while ( (line = input.ReadLine()) != null)
           yield return line;
    }
    var lineEmpNrs = ReadLines(HeaderFile)
       .Select(l => l.Split(','))
       .Select(l => new taMibMsftEmpDetails() 
           {
              EmployeeId   = l[1],
              EmployeeName = l[2],
              ExpenseDate  = l[3]
           })
       .OrderBy(l=> l.EmployeeId)
       .ToList();
