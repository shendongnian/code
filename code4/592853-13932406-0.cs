        [Test]
        public void Should_have_error_when_val_is_zero()
        {
            validator = new TestModelValidator();
            TestModel testRequest = new TestModel();
            //populate with dummy data
            var result = validator.Validate(testRequest);
            Assert.That(result.Errors.Any(o => o.PropertyName== "ParentVal"));
        }
