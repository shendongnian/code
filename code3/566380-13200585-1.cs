        [TestMethod]
        public void TestValidator()
        {
            FooBarValidator validator = new FooBarValidator();
            var result = validator.Validate(new FooBar());
        }
