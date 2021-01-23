    check<int> intChecker = new check<int>();
    Console.WriteLine(intChecker.CompareMyValue(4, 5).ToString());
    Console.ReadKey();
           
    check<string> strChecker = new check<string>();
    Console.WriteLine(strChecker.CompareMyValue("The test", "The test").ToString());
    Console.ReadKey();
            
    check<decimal> decChecker = new check<decimal>();
    Console.WriteLine(decChecker.CompareMyValue(1.23456m, 1.23456m).ToString());
    Console.ReadKey();
            
    check<DateTime> dateChecker = new check<DateTime>();
    Console.WriteLine(dateChecker.CompareMyValue(new DateTime(2013, 12, 25), new DateTime(2013, 12, 24)).ToString());
    Console.ReadKey();
