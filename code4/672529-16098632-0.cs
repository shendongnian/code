    List<string> list = new List<string>();
    string input = "";
    
    do
    {
       input = Console.ReadLine();
       list.Add(input);
    }
    while (input != "exit");
    list.Remove("exit");
    
    foreach (var item in list)
    {
       Console.WriteLine(item);
    }
