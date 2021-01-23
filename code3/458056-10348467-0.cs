    DateTime unixEpoch = new DateTime(1970, 1, 1);
    DateTime currentDate = DateTime.Now;
    long totalMiliSecond = (currentDate.Ticks - unixEpoch.Ticks) /10000;
    Console.WriteLine(totalMiliSecond);
    string fileName = string.Concat(totalMiliSecond,".jpg");
    Console.WriteLine(fileName);
