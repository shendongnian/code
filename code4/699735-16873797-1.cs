    public List<Course> GetActiveCourseSummary(QueryOver<Course, Course> queryOver)
    {
        var criteria = query.UnderlyingCriteria;
        var rootAlias = criteria.Alias;              // will return "courseAlias"
        var path = rootAlias + ".Student";           // the path
        var student = criteria.GetCriteriaByPath(path)
                ?? criteria.CreateCriteria(path, path);
        var studentAlias = student.Alias;            // finally we do have existing alias
        queryOver.And(Restrictions.Eq(studentAlias + ".Name ", "Bob"));
        ...
