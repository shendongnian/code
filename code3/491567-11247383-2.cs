    public class Competitor
    {
        private IList<CompetitorBest> _competitorBests;
        //other properties
        public virtual IEnumerable<CompetitorBest> CompetitorBests
        {
            get { return _competitorBests.ToArray(); }
            set { }
        }
    }
