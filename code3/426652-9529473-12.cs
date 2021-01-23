    string a = new string('x', 1);
    string b = new string('x', 1);
    Console.WriteLine(a == b); // Uses string's implementation, prints True
    object c = a;
    object d = b;
    Console.WriteLine(c == d); // Reference identity comparison, prints False
