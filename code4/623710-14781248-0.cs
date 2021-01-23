        [Fact]
        public void TestFeature()
        {
            var fake = A.Fake<IBlah>();
            A.CallTo(() => fake.ApplyFilter(A<Func<int, bool>>.Ignored)).ReturnsLazily(x =>
                {
                    return x.GetArgument<Func<int, bool>>("predicate");
                });
            var something = new Something(fake);
            var result = something.DoSomething(1, x => x > 1);
            Assert.False(result);
            A.CallTo(() => fake.ApplyFilter(A<Func<int, bool>>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
        }
