    public static IEnumerable<Stat> GetAdsStats(...)
    {
       ...
       var statList = new List<Stat>();
       for (int i = 0; i < reklamos; i++)
       {
            var stat = new Stat();
            statList.Add(stat);
            int dienos = kazkas.Ads[i].Days.Length;
            for (int lop = 0; lop < dienos; lop++)
            {
                AllClicks = AllClicks + kazkas.Ads[i].Days[lop].Stats.Clicks;
                AllImpresions = AllImpresions + kazkas.Ads[i].Days[lop].Stats.Impressions;
            }
            stat.Clicks = AllClicks;
            stat.Impression = AllImpresions;
        }
        return statList;
    }
