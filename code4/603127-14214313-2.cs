    class ProjectedData
    {
        public string name { get; set; }
        public string result { get; set; }
    }
    ...
    string item1 = "Name";
    string item2 = "Test_Result";
    Type studentType = typeof(Student);
    var itemParam = Expression.Parameter(studentType, "x");
    var member1 = Expression.PropertyOrField(itemParam, item1);
    var member2 = Expression.PropertyOrField(itemParam, item2);
    var selector = Expression.MemberInit(Expression.New(typeof(ProjectedData)),
        Expression.Bind(typeof(ProjectedData).GetMember("name").Single(), member1),
        Expression.Bind(typeof(ProjectedData).GetMember("result").Single(), member2)
    );
    var lambda = Expression.Lambda<Func<Student, ProjectedData>>(
        selector, itemParam);
    var currentItemFields = students.Select(lambda.Compile());
