    public List<Course> GetActiveCourseSummary(QueryOver<Course, Course> queryOver)
    {
        Address studentAlias = null;
        var query = queryOver.Where(() => studentAlias.Name == "Bob");
        ...
    }
