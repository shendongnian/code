        var linqStatements = new List<String>();
        
        linqStatements.Add(parser.StringToLinqQuery<Project>("ProjectId", report.Project));
        linqStatements.Add(parser.StringToLinqQuery<Region>("RegionId", report.Region));
        linqStatements.Add(parser.StringToLinqQuery<Status>("Status", report.Status));
        linqStatements.Add(parser.StringToLinqQuery<Priority>("Priority", report.Priority));
        linqStatements.Add(parser.StringToLinqQuery<Category>("CategoryId", report.Category));
        linqStatements.Add(AccountIdsToLinqQuery(report.PrimaryAssignment));
        
        string baseQuery = String.Join(" AND ", linqStatements.Where(s => !String.IsNullOrWhiteSpace(s)));
        var linqQuery = service.Mail.Where(baseQuery).Cast<Mail>();
