    private class Foo {
        public string Bar { get; set; }
    }
    private IEnumerable<Foo> SomeFoos = new List<Foo>() {
        new Foo{Bar = "Jan"},
        new Foo{Bar = "Feb"},
        new Foo{Bar = "Mar"},
        new Foo{Bar = "Apr"},
    };
    [TestMethod]
    public void GetDynamicProperty() {
            var expr = SelectExpression<Foo, string>("Bar");
            var propValues = SomeFoos.Select(expr);
            Assert.IsTrue(new[] { "Jan", "Feb", "Mar", "Apr" }.SequenceEqual(propValues));
        }
        
    public static Func<TItem, TField> SelectExpression<TItem, TField>(string fieldName) {
        var param = Expression.Parameter(typeof(TItem), "item");
        var field = Expression.Property(param, fieldName);
        return Expression.Lambda<Func<TItem, TField>>(field, new ParameterExpression[] { param }).Compile();
    }
