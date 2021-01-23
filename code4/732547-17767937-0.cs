    static bool HasIssueWithCode(this Org org, int issueNo)
    {
        return org.Issues.Any(issue => issue.Code == issueNo);
    }
    static bool HasIssueWithCode(this Item items, int issueNo)
    {
        return items.ItemOrganizations.Any(org => org.HasIssueWithCode(issueNo));
    }
