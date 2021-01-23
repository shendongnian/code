    using LumenWorks.Framework.IO.Csv;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    namespace TestProgram
    {
        class Product
        {
            public string Action { get; set; }
            public string CategoryPath { get; set; }
            public int ID { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public int Stock { get; set; }
        }
    
        static class Extensions
        {
            public static string DoubleQuoteString(this string str)
            {
                return '"' + str + '"';
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var resellersInventoryQuery = from lineTokens in ReadCsvLines("data\\Resellers_Inventory.txt", true, '|')
                                              select new { Code = lineTokens[0], Stock = Convert.ToInt32(lineTokens[1]) };
    
                Dictionary<string, int> orderStock = resellersInventoryQuery.ToDictionary(kvp => kvp.Code, kvp => kvp.Stock);
    
                var allProductsQuery = from lineTokens in ReadCsvLines("data\\ProductAll.txt", true, ',')
                                       let product = ParseProduct(lineTokens)
                                       select product;
    
                using (StreamWriter sw = File.CreateText("data\\updated.txt"))
                {
                    foreach (var product in allProductsQuery)
                    {
                        if (orderStock.ContainsKey(product.Code))
                        {
                            int newStockValue = orderStock[product.Code];
                            if (newStockValue != product.Stock)
                            {
                                product.Stock = orderStock[product.Code];
                                sw.WriteLine(ToString(product));
                            }
                        }
                    }
                }
    
            }
    
            static IEnumerable<string[]> ReadCsvLines(string file, bool hasHeader, char delimiter)
            {
                using (CsvReader csr = new CsvReader(new StreamReader(file), hasHeader, delimiter))
                {
                    int fieldCount = csr.FieldCount;
                    while (csr.ReadNextRecord())
                    {
                        List<string> lineTokens = new List<string>();
                        for (int i = 0; i < fieldCount; i++)
                            lineTokens.Add(csr[i]);
                        yield return lineTokens.ToArray();
                    }
                }
            }
    
            static Product ParseProduct(string[] tokens)
            {
                Product product = new Product();
    
                product.Action = tokens[0];
                product.CategoryPath = tokens[1];
                product.ID = Convert.ToInt32(tokens[2]);
                product.Name = tokens[3];
                product.Code = tokens[4];
                product.Stock = Convert.ToInt32(tokens[5]);
    
                return product;
            }
    
            static string ToString(Product product)
            {
                const char SEPERATOR = ',';
    
                StringBuilder sb = new StringBuilder();
                sb.Append(product.Action.DoubleQuoteString()); sb.Append(SEPERATOR);
                sb.Append(product.CategoryPath.DoubleQuoteString()); sb.Append(SEPERATOR);
                sb.Append(product.ID); sb.Append(SEPERATOR);
                sb.Append(product.Name.DoubleQuoteString()); sb.Append(SEPERATOR);
                sb.Append(product.Code.DoubleQuoteString()); sb.Append(SEPERATOR);
                sb.Append(product.Stock);
    
                return sb.ToString();
            }
        }
    }
