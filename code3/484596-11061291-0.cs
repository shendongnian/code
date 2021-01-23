    searchText = searchText.ToUpper();
    List<string> searchTerms = searchText.Split(' ').ToList();
    var allIssues =
        from iss in DatabaseConnection.CustomerIssues
        join stoi in DatabaseConnection.SolutionToIssues on iss.IssueID equals stoi.IssueID into stoiToiss
        from stTois in stoiToiss.DefaultIfEmpty()
        join solJoin in DatabaseConnection.Solutions on stTois.SolutionID equals solJoin.SolutionID into solutionJoin
        from solution in solutionJoin.DefaultIfEmpty()
        select new IssuesAndSolutions
        {
            IssueID = iss.IssueID,
            IssueDesc = iss.Description,
            SolutionDesc = (solution.Description == null) ? "No Solutions" : solution.Description,
            SolutionID = (solution.SolutionID == null) ? 0 : solution.SolutionID,
            SolutionToIssueID = (stTois.SolutionToIssueID == null) ? 0 : stTois.SolutionToIssueID,
            Successful = (stTois.Successful == null) ? false : stTois.Successful
        };                
        List<IssuesAndSolutions> filteredIssues = new List<IssuesAndSolutions>();
                
        foreach (var issue in allIssues)
        {
            int hits = 0;
            foreach (var term in searchTerms)
            {
                if (issue.IssueDesc.ToUpper().Contains(term.Trim())) hits++;                        
            }
            if (hits > 0)
            {
                 IssuesAndSolutions matchedIssue = new IssuesAndSolutions();
                 matchedIssue.IssueID = issue.IssueID;
                 matchedIssue.IssueDesc = issue.IssueDesc;
                 matchedIssue.SearchHits = hits;
                 matchedIssue.CustomerID = issue.CustomerID;
                 matchedIssue.AssemblyID = issue.AssemblyID;
                 matchedIssue.DateOfIssue = issue.DateOfIssue;
                 matchedIssue.DateOfResolution = issue.DateOfResolution;
                 matchedIssue.CostOFIssue = issue.CostOFIssue;
                 matchedIssue.ProductID = issue.ProductID;
                 filteredIssues.Add(matchedIssue);
             }                    
          }
