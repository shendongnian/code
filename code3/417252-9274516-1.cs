    string enteredByUser = Console.ReadLine();
    // uses user-specific Windows settings (decimal separator might be ",")
    double myDouble1 = double.Parse(enteredByUser);
    // uses default settings (decimal separator is always ".")
    double myDouble2 = double.Parse(enteredByUser, CultureInfo.InvariantCulture);
