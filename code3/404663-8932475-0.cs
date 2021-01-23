    String[] Months = new String[] {"Jan", "Feb"}; //put all months in
    Console.WriteLine("Please the month numerically");
    string date = Console.ReadLine();
    int index = 0;
    if (!int.TryParse(date, out index)) {
        // handle error for input not being an int
    }
    dt = Months[index];
