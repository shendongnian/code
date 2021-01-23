    public List<Comment> GetComments(long problemID)
    {
        return _objectModel.Comments.Where(c => c.ProblemID == problemID)
                                    .ToList(); // Force evaluation
    }
