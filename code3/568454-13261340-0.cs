    var lambdaExpression = iQueryable.Expression;
    var whereClause = (Expression<Func<User, bool>>) 
                        ((UnaryExpression) 
                            ((MethodCallExpression) lambdaExpression
                            ).Arguments[1]
                        ).Operand;
    var explainDoc = _users.Find(Query<User>.Where(whereClause)).Explain();
    Console.WriteLine(BsonExtensionMethods.ToJson(explainDoc));
    var queryDoc = BsonExtensionMethods.ToJson(Query<User>.Where(whereClause));
    Console.WriteLine(queryDoc);
