    public IEnumerable<string> GetComments(long problemID)
    {
        var query = from c in _objectModel.Comments
                    where c.ProblemID == problemID
                    select new { c.EmpID, c.CommentText, c.Time };
        return query.AsEnumerable() // Do the rest locally
                    .Select(c => string.Format("{0} {1} {2"}, c.EmpID,
                                               c.CommentText, c.Time));
    }
