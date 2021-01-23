    const long TwoYearsInDays = 2 * 365;
    string recordTime = fileName.Split('_','-').Last();// format is 'yyyyMMddHHmmss'
    DateTime recordDateTime = new DateTime( Int32.Parse( recordTime.Substring( 0, 4 ), //year
                                            Int32.Parse( recordTime.Substring( 4, 2 ), //month
                                            Int32.Parse( recordTime.Substring( 6, 2 ), //day
                                            Int32.Parse( recordTime.Substring( 8, 2 ), //hour
                                            Int32.Parse( recordTime.Substring( 10, 2 ), //minute
                                            Int32.Parse( recordTime.Substring( 12, 2 ) ); //second
    var dateDifference = DateTime.Now - recordDateTime;
    if ( dateDifference.Days > TwoYearsInDays )
    {
        Console.WriteLine(fileName);
    }
