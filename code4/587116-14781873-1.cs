       [Fact]
        public void TestFeature()
        {
            var fake = A.Fake<IBlah>();
            var something = new Something(fake);
            something.DoSomething(1, 2);
            var callResults = Fake.GetCalls(fake).Any(call =>
             {
                 var x = call.GetArgument<int>("x");
                 var y = call.GetArgument<int>("y");
                 return call.Method.Name == "Add" || call.Method.Name == "Subtract"
                     && x == 1 && y == 2;
             });
            Assert.True(callResults);
        }
