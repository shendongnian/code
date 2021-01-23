    private IEnumerable<SubjectSelectorSubjectGroup> GetSubjectList()
    {
        List<string> userSubjects = new List<string>();
        if (HttpContext.Current.Request.IsAuthenticated)
        {
            User user = db.Users.Find(WebSecurity.CurrentUserId);
            if (user.Elective1 != null) { userSubjects.Add(user.Elective1.SubjectId); }
            if (user.Elective2 != null) { userSubjects.Add(user.Elective2.SubjectId); }
            if (user.Elective3 != null) { userSubjects.Add(user.Elective3.SubjectId); }
        }
        return db.RequiredSubjects.Where(r => !r.Subject.Name.Contains("Home"))
                                  .GroupBy(r => r.Subject)
                                  .OrderByDescending(r => r.Count())
                                  .Select(r => new SubjectSelectorSubjectGroup()
                                  {
                                       SubjectId = r.Key.SubjectId,
                                       SubjectName = r.Key.Name,
                                       IsInFavourites = userSubjects.Contains(r.Key.SubjectId),
                                       Occurrences = r.Count()
                                  });
    }
