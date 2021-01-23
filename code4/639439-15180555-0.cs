    bool valid = true; // locally declared variable, this is important!
    
    string value = Console.ReadLine();
    valid = validateInput(value);
    
    if (valid == true) {
    double value1 = Convert.ToDouble(value);
    // Proceed with calculations, etc
    }
    
    private bool validateInput(string value) {
    bool valid = true;
    foreach (char c in value)
        {
            if (char.IsLetter(c))
                valid = false;
            Console.WriteLine("Input is invalid!");
        }
    return valid;
    }
