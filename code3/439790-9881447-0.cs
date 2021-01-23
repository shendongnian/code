        List<string> myList1 = MyStaticClass.MyList; 
        List<string> myList2 = MyStaticClass.MyList; 
        myList1.Add("Hello");  // Add to first list
        myList2.Add("World");  // Add to second list 
        foreach(string item in myList1) // print all items in the second list
        {
             Console.WriteLine("List 1: " + item); 
        }
        foreach(string item in myList2) // print all items in the second list
        {
             Console.WriteLine("List 2: " + item); 
        }
