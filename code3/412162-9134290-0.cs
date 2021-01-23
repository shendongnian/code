    var testNumbers = new List<object>();
    testNumbers.Add(15);
    testNumbers.Add("AUUUGHH");
    testNumbers.Add(42);
    
    foreach (var i in testNumbers)
        Console.WriteLine(Microsoft.VisualBasic.Information.IsNumeric(i));
