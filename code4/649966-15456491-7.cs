    const int NumberOfCandidates = 4;
    var votingResults = new List<VotingResult>();
    foreach (string s in voting) {
        votingResult = new VotingResult(NumberOfCandidates);
        votingResult.Precinct = s.Substring(0, 1);
        for (int cand = 0; cand < NumberOfCandidates; cand++) {
            votingResult.Candidates[cand] = Convert.ToInt32(s.Substring(3 * cand + 1, 3));
        }
        votingResults.Add(votingResult);
    }
