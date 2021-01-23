            //to define the string array
     string[] array_1 = new string[]
                                       {
                                           "string 1",
                                           "string 2",
                                           "string 3",
                                           "string 4"
                                       };
    
    // To access the string using foreach loop
    
                foreach (string str in array_1)
                    Console.WriteLine(str);
           // To access the string using index
       
        for (int i = 0; i < array_1.Length;i++ ) 
                Console.WriteLine(array_1[i]);
