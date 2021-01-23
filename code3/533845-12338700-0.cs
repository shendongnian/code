    List<DateTime> listOfDates = new List<DateTime>();
    listOfDates.Add(new DateTime(2012, 01, 04));
    listOfDates.Add(new DateTime(2012, 01, 05));
    listOfDates.Add(new DateTime(2012, 01, 06));
    listOfDates.Add(new DateTime(2012, 01, 31));
    listOfDates.Add(new DateTime(2012, 02, 01));
    listOfDates.Add(new DateTime(2012, 02, 28));
    listOfDates.Add(new DateTime(2012, 03, 01));
    listOfDates.Add(new DateTime(2012, 03, 16));
    var filterdListByMonth = listOfDates.Where(date => date.Month >= 1 && date.Month <= 2);
    // Outputs each date except the two in March.
    Console.WriteLine(String.Join(Environment.NewLine, filterdListByMonth));
