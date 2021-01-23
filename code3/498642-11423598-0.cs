    void Main()
    {
        var list1 = new List<TradeFile>(new [] {
            new TradeFile { Name = "TradeFile1", Data = "a" },
            new TradeFile { Name = "TradeFile2",  Data = "b" },
        });
        
        var list2 = new List<TradeFile>(new [] {
            new TradeFile { Name = "TradeFile4",  Data = "a" },
            new TradeFile { Name = "TradeFile5",  Data = "c" },
        });
        
        var query = from tradeFile1 in list1
                    from tradeFile2 in list2
                    select new TradeFileComparison(tradeFile1, tradeFile2);
                    
        foreach (var item in query)
        {
            Console.WriteLine(item.ToString());
        }
    }
    
    class TradeFile
    {
        public string Name { get; set; }
        
        public string Data { get; set; }
        
        public bool Matches(TradeFile otherTradeFile)
        {
            return (this.Data == otherTradeFile.Data);
        }
    }
    
    class TradeFileComparison
    {
        public TradeFileComparison(TradeFile tradeFile1, TradeFile tradeFile2)
        {
            this.TradeFile1 = tradeFile1;
            this.TradeFile2 = tradeFile2;
        }
        
        public TradeFile TradeFile1 { get; set; }
        
        public TradeFile TradeFile2 { get; set; }
        
        bool IsMatch { get { return this.TradeFile1.Matches(TradeFile2); } }
        
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", 
                this.TradeFile1.Name, this.TradeFile2.Name, 
                this.IsMatch.ToString());
        }
    }
