    MyClass m = new MyClass();
    List<MyClass> myList = new List<MyClass>();
    myList.Add(m);
    myList[0].Number += 1;
    Console.WriteLine(myList[0].Number); // Displays 1
    Console.WriteLine(m.Number); // Displays 1
    myList[0].Number += 1;
    Console.WriteLine(myList[0].Number); // Displays 2
    Console.WriteLine(m.Number); // Displays 2
