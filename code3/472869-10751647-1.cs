    System.DateTime localDateTime;
    try {
        localDateTime = System.DateTime.Parse(strDateTime);
    }
    catch (System.FormatException) {
        System.Console.WriteLine("Invalid format.");
        return;
    }
