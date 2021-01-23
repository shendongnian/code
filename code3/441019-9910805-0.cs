        class Data
        {
            public int Qty { get; set; }
            public double Price { get; set; }
            public string Date { get; set; }
        }
        static void Main(string[] args)
        {
            var data = new Data[] { 
                new Data { Qty = 5, Price = 2, Date = "1/25"  },
                new Data { Qty = 6, Price = 1, Date = "1/25"  },
                new Data { Qty = 8, Price = 3, Date = "4/25"  },
                new Data { Qty = 1, Price = 2, Date = "4/25"  },
            };
            var weighted = data.GroupBy(x => x.Date)
                               .Select(group => new Data { 
                                   Date = group.Key, 
                                   Qty = group.Sum(i => i.Qty), 
                                   Price = group.Sum(i => i.Price * i.Qty) / group.Sum(i => i.Qty)
                           });            
        }
