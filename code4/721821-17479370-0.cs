    item.Expect(i => i.SetValues(Arg<IDictionary<string, object>>.Is.Anything))
        .WhenCalled(invocation =>
        {
            var items = invocation.Arguments
                .OfType<IDictionary<string, object>>()
                .First();
            Assert.That(items.Count(), Is.EqualTo(1));
            Assert.That(items.First().Key, Is.EqualTo("Date");
            // ...
        });
