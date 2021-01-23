    MyCustomInt a = new MyCustomInt(0);
    a.MyInt = 5;
    a.IsMutable = false;
    a.MyInt = 3; //Won't change here!
    Console.WriteLine(a); //Prints 5 and not 3
