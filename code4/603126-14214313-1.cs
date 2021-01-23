    string item1 = "Name";
    string item2 = "Test_Result";
    Type studentType = typeof(Student);
    var itemParam = Expression.Parameter(studentType, "x");
    var member1 = Expression.PropertyOrField(itemParam, item1);
    var member2 = Expression.PropertyOrField(itemParam, item2);
    var selector = Expression.Call(typeof(Tuple), "Create",
        new[] { member1.Type, member2.Type }, member1, member2);
    var lambda = Expression.Lambda<Func<Student, Tuple<string,string>>>(
        selector, itemParam);
    var currentItemFields = students.Select(lambda.Compile());
