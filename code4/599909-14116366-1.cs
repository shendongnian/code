    List<string[]> stock = new List<string[]>(File.ReadAllLines("G:\\Stock.txt").Select(line => line.Split('|')));
    List<string[]> products = new List<string[]>(File.ReadAllLines("G:\\Products.txt").Select(line => line.Split(',')));
    products.ForEach(p =>
    {
        // since not all arrays in this case are the same lenght, we will go backwards from the end
        int productStockIndex = Array.IndexOf(p, p.Last());
        // product name is before the stock count
        int productNameIndex = productStockIndex - 1;
        // get product name to find in Stock.txt and remove extra quotes from product name
        string productName = p[productNameIndex].Replace("\"", "");
        // check if Stock.txt contains the product
        if (stock.Any(s => s[0] == productName))
        {
            // Update the stock count
            p[productStockIndex] = stock.First(stk => stk[0] == productName)[1];
        }       
    });
