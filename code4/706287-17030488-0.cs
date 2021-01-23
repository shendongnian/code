    using namespace System;
    using namespace System.Linq;
    
    static Tuple<int, string> ParseLine(string line)
    {
        var tokens = line.Split(); // Split by spaces
        var number = int.Parse(tokens[1]); // The number is the 2nd token
        var address = string.Join(" ", tokens.Skip(2)); // The address is every subsequent token
        address = address.Substring(1, address.Length - 2); // ... minus the first and last characters
        return Tuple.Create(number, address);
    }
