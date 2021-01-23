    string s = Console.ReadLine();
    string[] values = s.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    string stringValue0 = values[0];
    int numericValue1 = int.Parse(value[1]); // Assuming the value is an valid interger.
    int numericValue2 = int.Parse(value[2]); // Assuming the value is an valid interger.
    int numericvalue3;
    string stringValue3;
    if (!int.TryParse(values[3], out numericValue3) // Trying to convert the text to an interger. If it fails, assign it to the stringValue3.
        stringValue3 = values[3];
