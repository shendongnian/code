        private void UpdateProducts()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                DateTime start = DateTime.Now;
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
                File.WriteAllLines(@"C:\Results.txt", products.Select(p => string.Join(",", p)).ToArray());
                MessageBox.Show(string.Format("Done :), Process took {0} seconds to complete.",(DateTime.Now - start).TotalSeconds));
            });
        }
