        private void UpdateProducts()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                DateTime start = DateTime.Now;
                List<string> updatedProducts = new List<string>();
                List<string[]> stock = new List<string[]>(File.ReadAllLines("G:\\Stock.txt").Select(line => line.Split('|')));
                List<string> products = new List<string>(File.ReadAllLines("G:\\Products.txt"));
                updatedProducts.Add(products[0]);
                SetProgress(products.Count);
                foreach (var item in products)
                {
                    if (stock.Any(s => item.Contains(s[0]) && !item.EndsWith(s[1])))
                    {
                        string[] p = item.Split(',');
                        int productStockIndex = Array.IndexOf(p, p.Last());
                        int productNameIndex = productStockIndex - 1;
                        string productName = p[productNameIndex].Replace("\"", "");
                        p[productStockIndex] = stock.First(stk => stk[0] == productName)[1];
                        updatedProducts.Add(string.Join(",", p));
                    }
                    UpdateProgress(updatedProducts.Count);
                }
                File.WriteAllLines(@"G:\Results.txt", updatedProducts.ToArray());
            });
        }
        private void SetProgress(int maxValue)
        {
            base.Invoke((Action)delegate 
            {
                progressBar1.Maximum = maxValue;
            });
        }
        private void UpdateProgress(int value)
        {
            base.Invoke((Action)delegate
            {
                progressBar1.Value = value;
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateProducts();
        }
