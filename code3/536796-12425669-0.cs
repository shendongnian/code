    List<myClass> = new List<myClass>();
    myClass myObject = new myClass();
    myObject.x = 5;
    
    myList.Add(myObject);
    Console.WriteLine(myList[0].x); //this will be 5
    
    myObject.x = 7;
    Console.WriteLine(myList[0].x); //this will be 7
