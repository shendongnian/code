<!-- -->
    // helper method
    static Expression AddAssignStrings(ParameterExpression left, Expression right)
    {
        var stringType = typeof(string);
        var concatMethod = stringType.GetMethod("Concat", new[] { stringType, stringType });
        return Expression.Assign(
            left,
            Expression.Call(concatMethod, left, right)
        );
    }
    var text = Expression.Parameter(typeof(string), "text");
    var world = Expression.Parameter(typeof(World), "world");
    var player = Expression.Parameter(typeof(Player), "player");
    var output = Expression.Variable(typeof(string), "output");
    // looks safe to reuse this array for the expressions
    var arguments = new ParameterExpression[] { text, world, player };
    var someClassType = typeof(SomeClass);
    // assuming the methods are all publicly accessible
    var printStartingMethod = someClassType.GetMethod("PrintStarting");
    var existsMethod = someClassType.GetMethod("Exists");
    var printNameMethod = someClassType.GetMethod("PrintName");
    var killPlayerMethod = someClassType.GetMethod("KillPlayer");
    var printSurvivedMethod = someClassType.GetMethod("PrintSurvived");
    var printNotExistsMethod = someClassType.GetMethod("PrintNotExists");
    var ifTrueBlockContents = new Expression[]
    {
        AddAssignStrings(output, Expression.Call(printNameMethod, arguments)),
        Expression.Call(killPlayerMethod, arguments),
        Expression.IfThen(
            Expression.Call(existsMethod, arguments),
            AddAssignStrings(output, Expression.Call(printSurvivedMethod, arguments))
        ),
    };
    var blockContents = new Expression[]
    {
        Expression.Assign(output, Expression.Call(printStartingMethod)),
        Expression.IfThenElse(
            Expression.Call(existsMethod, arguments),
            Expression.Block(ifTrueBlockContents),
            AddAssignStrings(output, Expression.Call(printNotExistsMethod, arguments))
        ),
        output,
    };
    var body = Expression.Block(typeof(string), new ParameterExpression[] { output }, blockContents);
    var lambda = Expression.Lambda<Func<string, World, Player, string>>(body, arguments);
