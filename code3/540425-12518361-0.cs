    public List<SummaryReport> CreateReport()
    {
     return Get()
         .SelectMany(rev => rev.Assessments, (rev, ass) => new { rev, ass })
         .Select(x => new SummaryReport
         {
             ReviewID = x.rev.ReviewID,
             ReviewerID = x.ass.Reviewer.ReviewerID,
             Assessment = x.ass.Assessment,
             ReviewGroupID = x.ass.Reviewer.ReviewGroup.ReviewGroupID,
             GroupAssessment = DeriveGroupAssessment(x.rev.Assessments)
          })
         .ToList();
     }
    private static string DeriveGroupAssessment(IEnumerable<Assessment> assessments)
    {
      string assessment = null;
      if (assessments.Any(a => a.AssessmentDescription == "Big Problem"))
      {
        assessment = "Big Problem";
      }
      else if (assessments.All(a => a.AssessmentDescription == "No Problem"))
      {
        assessment = "No Problem";
      }
      // Not needed as assessment will already be null
      ////if (!assessments.Any(a => a.AssessmentDescription == "Big Problem")
      ////    && assessments.Any(a => a.AssessmentDescription == string.Empty))
      ////{
      ////  assessment = null;
      ////}
      return assessment;
    }
