    public class VotingResult
    {
        public VotingResult(int numberOfCandidates)
        {
            Candidates = new int[numberOfCandidates];
        }
        public string Precinct { get; set; }
        public int[] Candidates { get; private set; }
        public int PrecinctTotal { get { return Candidates.Sum(); } }
    }
