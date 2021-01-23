    List<string> list = new List<string>();
    list.Add("first element");
    list.Add("2nd element");
    Console.Write(list[0]);
    Console.Write(list[1]);
    list[0] = "AAA - element"; //In actual its a modification, 
                               //if there is no element, there will b exception
    list[1] = "BBB - element";
