    var visitor = dbConnection.CreateExpression<Person>();
    visitor.Where(x => x.FirstName.StartsWith("Jim")).And(x => x.LastName.StartsWith("Hen"));
    var results = db.Select<Person>(visitor);
    Assert.AreEqual(1,results.Count);
    visitor.Where(x => x.Age < 30).Or(x => x.Age > 45);
    results = db.Select<Person>(visitor);
    Assert.AreEqual(5, results.Count);
    Assert.IsFalse(results.Any(x => x.FirstName == "Elvis"));
