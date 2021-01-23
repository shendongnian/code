    string datestring = "Thu Jun 09 2011 00:00:00 GMT+0530 (India Standard Time)";
    string[] s1 = datestring.Split(new string[]{" "}, 6, StringSplitOptions.RemoveEmptyEntries);
    
    string date = "";
    for (int i = 0; i < 5; i++)
    {
         date = date + s1[i] + " ";
    }
    date = date.TrimEnd();
    
    DateTime yourdatetime = DateTime.ParseExact(date, "ddd MMM dd yyyy HH:mm:ss", CultureInfo.InvariantCulture);
    Console.WriteLine(yourdatetime);
