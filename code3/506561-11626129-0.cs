    IEnumerable<string> htmlSnippets = jobseekers
        .Zip(Enumerable.Range(0, jobseekers.Count), Tuple.Create)
        .GroupBy(tup => tup.Item2 / 3)
        .Select(GenerateHtmlString);
    string combinedHtmlString = string.Join(string.Empty, htmlSnippets);
    public string GenerateHtmlString(IEnumerable<MemberProfile> profiles)
    {
        return string.Format(@"<div class=""jobseeker"">{0}</div>",
            // The question doesn't specify how the 3 jobseekers are rendered in HTML
            );
    }
