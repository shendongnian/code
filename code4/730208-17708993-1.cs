    Regex regex = new Regex(@"\d{3}-?\d{3}-?\d{4}");
    string phonenumber = Console.ReadLine();
    while (!regex.IsMatch(phonenumber))
    {
        Console.WriteLine("Bad Input");
        phonenumber = Console.ReadLine();
    }
    return Convert.ToInt32(phonenumber.Replace("-",""));
