    List<string> list1 = new List<string>();
    list1.Add("hello"); // OK
    list1.Add(123); // Compiler error
    List<int> list2 = new List<int>();
    list2.Add("hello"); // Compiler error
    list2.Add(123); // OK
