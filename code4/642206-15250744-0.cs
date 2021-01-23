    String myString = "abc";
    bool test1 = myString.Substring(2, 1).Equals("c"); // This is true.
    Console.WriteLine(test1);
    bool test2 = String.IsNullOrEmpty(myString.Substring(3, 0)); // This is true.
    Console.WriteLine(test2);
    try {
       string str3 = myString.Substring(3, 1); // This throws ArgumentOutOfRangeException.
       Console.WriteLine(str3);
    }
    catch (ArgumentOutOfRangeException e) {
       Console.WriteLine(e.Message);
    }
