    List<List<string>> myList = new List<List<string>>();
    myList.Add(new List<string>());
    myList[0].Add("http://www.aaa.com");
    myList.Add(new List<string>());
    myList[1].Add("http://www.bbb.com");
    myList[1].Add("http://www.bb1.com");
    // and so on...
    Console.WriteLine(myList[0][0]);   // displays http://www.aaa.com
    Console.WriteLine(myList[1][0]);   // displays http://www.bbb.com
    Console.WriteLine(myList[1][1]);   // displays http://www.bb1.com
