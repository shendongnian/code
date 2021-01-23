    public class RankGroup
    {
        public int Rank { get; set; }
        public int RankCount { get; set; }
    
        public override string ToString()
        {
            return string.Format("Rank Number: {0} Rank Number Count: {1}", Rank, RankCount);
        }
    }
    
    var rankGroups = myDataSet.Table[0].Rows.Cast<Row>().Select(r =>
                                        new RankGroup
                                        {
                                            Rank = r.Field<int>("rank"),
                                            RankCount = r.Field<int>("rankCount")
                                        }
    
    foreach(var rankGroup in rankGroups)
    {
        Console.WriteLine(rank);
    }
