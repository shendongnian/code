    var blockExp = Expression.Block(
        new[] { inputVar }
        , Expression.Assign(inputVar, Expression.Constant(10))
        , Expression.Call(typeof(Program).GetMethod("TwiceTheInputByRef", new [] { typeof(int).MakeByRefType() }), inputVar)
        , inputVar
    );
