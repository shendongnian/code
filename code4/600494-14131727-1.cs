    private void UpdateProducts()
    {
        List<string[]> stock = new List<string[]>(File.ReadAllLines("C:\\Stock.txt").Select(line => line.Split('|')));
        List<string[]> products = new List<string[]>(File.ReadAllLines("C:\\Products.txt").Select(line => line.Split(',')));
        products.ForEach(p =>
        {
            int productStockIndex = Array.IndexOf(p, p.Last());
            int productNameIndex = productStockIndex - 1;
            string productName = p[productNameIndex].Replace("\"", "");
            if (stock.Any(s => s[0] == productName))
            {
                p[productStockIndex] = stock.First(stk => stk[0] == productName)[1];
            }
        });
        // since we never modified the split values except the stock couunt we can just put
        // the array back together using String.Join.
        File.WriteAllLines(@"C:\Results.txt", products.Select(p => string.Join(",", p)));
    }
