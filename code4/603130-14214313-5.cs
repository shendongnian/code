    string[] fields = {"Name", "Test_Result"};
    Type studentType = typeof(Student);
    var itemParam = Expression.Parameter(studentType, "x");
    var addMethod = typeof(Dictionary<string, object>).GetMethod(
        "Add", new[] { typeof(string), typeof(object) });
    var selector = Expression.ListInit(
            Expression.New(typeof(Dictionary<string,object>)),
            fields.Select(field => Expression.ElementInit(addMethod,
                Expression.Constant(field),
                Expression.Convert(
                    Expression.PropertyOrField(itemParam, field),
                    typeof(object)
                )
            )));
    var lambda = Expression.Lambda<Func<Student, Dictionary<string,object>>>(
        selector, itemParam);
    var currentItemFields = students.Select(lambda.Compile());
