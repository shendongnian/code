    Dictionary<string,int> myStocks = new Dictionary<string,int>();
    //....
                case "1":
                    Console.WriteLine("Enter ticker to buy:");
                    stockTicker = Console.ReadLine();
                    Console.WriteLine("Enter stock price");
                    price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Quantity");
                    amount = int.Parse(Console.ReadLine());
                    int currAmount = 0;
                    myStocks.TryGetValue(stockTicker,out currAmount);
                    myStocks[stockTicker] = currAmount + amount;
                    Console.WriteLine("***Stock Purchased***");
                    break;
