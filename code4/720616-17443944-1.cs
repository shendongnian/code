    class HorribleNameThatYouCannotSay {
        public string wantedKey; // yes, a public field
    }
    ...
    static void Sample()
    {
        var ctx = new HorribleNameThatYouCannotSay();
        ctx.wantedKey = Console.ReadLine();
        var p = Expression.Parameter(typeof(SomeClass), "c");
        Expression<Func<SomeClass, bool>> expression =
            Expression.Lambda<Func<SomeClass, bool>>(
                Expression.Equal(
                    Expression.PropertyOrField(p, "Key"),
                    Expression.PropertyOrField(
                        Expression.Constant(ctx), "wantedKey")
                    ), p);
        );
    }
