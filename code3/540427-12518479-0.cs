     public static List<SummaryReport> CreateReport()
        {
            return Get()
                .SelectMany(rev => rev.Assessments, (rev, ass) => new { rev, ass })
                .Select(x => new SummaryReport
                {
                    ReviewID = x.rev.ReviewID,
                    ReviewerID = x.ass.Reviewer.ReviewerID,
                    Assessment = x.ass.AssessmentStr,
                    ReviewGroupID = x.ass.Reviewer.ReviewGroup.ReviewGroupID,
                    GroupAssessment = x.rev.Assessments.Any(a => a.AssessmentStr == "Big Problem") ? "Big Problem" : 
                    x.rev.Assessments.All(a => a.AssessmentStr == "No Problem")? "No Problem" : null
                })
                .ToList();
        }
