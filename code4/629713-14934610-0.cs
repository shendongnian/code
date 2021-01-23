        var mi = this.GetType().GetMethod("DoSomething");
        var actArg = mi.GetParameters()[0];
        var args = actArg.ParameterType.GenericTypeArguments;
        var lt = Expression.Label();
        List<object> values = new List<object>();
        
        var valVar = Expression.Variable(typeof(List<object>), "vals");
        var para = args.Select(a => Expression.Parameter(a))
            .ToArray();
        var setters = new List<Expression>();
        foreach (var p in para)
        {
            setters.Add(Expression.Call(valVar,
                typeof(List<object>).GetMethod("Add", new[] { typeof(object) }), p));
        }
        var block = Expression.Block(
            variables: new ParameterExpression[]
            {
                valVar,
            },
            expressions: Enumerable.Concat(para,
            new Expression[]
            {
                Expression.Assign(valVar, Expression.Constant(values)),
            }.Concat(setters)
            .Concat(new Expression[]
            {
                Expression.Return(lt),
                Expression.Label(lt),
            })));
        var l = Expression.Lambda(block, para).Compile();
        mi.Invoke(this, new object[] { l });
