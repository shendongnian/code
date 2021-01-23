    List<int> input = new List<int>();
    // first read input till there are nonempty items, means they are not null and not ""
    // also add read item to list do not need to read it again    
    string line;
    while ((line = Console.ReadLine()) != null && line != "") {
         input.Add(int.Parse(line));
    }
    
    // there is no need to use ElementAt in C# lists, you can simply access them by 
    // their index in O(1):
    StockItem[] stock = new StockItem[input.Count];
    for (int i = 0; i < stock.Length; i++) {
        stock[i] = new StockItem(input[i]);
    }
