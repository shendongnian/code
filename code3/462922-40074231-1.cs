        // Define a master condition, using named parameters.
        var masterExpr = LinqExprHelper.NewExpr(
            (Store s, bool bSearchName, bool bSearchDesc)
            => (bSearchName && bSearchDesc));
        // Replace stub parameters with some real conditions.
        var combExpr = masterExpr
            .ReplacePar("bSearchName", Store.SafeSearchName("b").Body)
            .ReplacePar("bSearchDesc", Store.SafeSearchDesc("p").Body);
            // Sometimes you may skip a condition using this syntax:
            //.ReplacePar("bSearchDesc", Expression.Constant(true));
        // It's interesting to see how the final expression looks like.
        Console.WriteLine("expr: " + combExpr);
 
       // Execute the query using combined expression.
       db.Stores
            .Where((Expression<Func<Store, bool>>)combExpr)
            .ToList().ForEach(i => { Console.WriteLine(i.Name + ", " + i.Description); });
