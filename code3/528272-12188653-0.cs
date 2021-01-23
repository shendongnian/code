<!-- -->
    var items = new[]
    {
        new SomeObject { Value = "foo" },
        new SomeObject { Value = "bar" },
        new SomeObject { Value = "baz" },
    };
    var something = "foo";
    var somethingElse = "baz";
    var result = items.Aggregate(
        Tuple.Create(default(SomeObject), default(SomeObject)),
        (acc, item) => Tuple.Create(
            item.Value == something     ? item : acc.Item1,
            item.Value == somethingElse ? item : acc.Item2
        )
    );
    // result.Item1 <- a == new SomeObject { Value = "foo" }
    // result.Item2 <- b == new SomeObject { Value = "baz" }
