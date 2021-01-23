    if (c == '!') {
        break;
    }
    else if (char.IsLower(c)) {
        // it's fine!
        Console.WriteLine("OK");
    }
    else {
        // it's not a lowercase character
        Console.WriteLine("Not a lowercase character");
    }
