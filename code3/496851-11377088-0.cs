    //to PRTime
    var yourDate = DateTime.UtcNow;
    TimeSpan t = (yourDate - new DateTime(1970, 1, 1));
    double PRTime = t.TotalMilliseconds * 1000;
    Console.WriteLine(PRTime);
    
    // and back from PRTime
    var someDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
    var milliSeconds = PRTime / 1000;
    var thatDate = someDate.AddMilliseconds(milliSeconds);
