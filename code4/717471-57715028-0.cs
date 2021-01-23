       [TestMethod]
            public void TestYourValidationModel()
            {
                var configuration = new HttpConfiguration();
                configuration.Filters.Add(new ValidateModelAttribute());
                // Get the quote
                var controller = new YourController
                {
                    Request = new HttpRequestMessage(),
                    Configuration = configuration
                };
                var request = YourRequestObject;
                controller.Request.Content = new ObjectContent<YourRequestType>(
                    request, new JsonMediaTypeFormatter(), "application/json");
                controller.Validate(request);
                Assert.IsTrue(controller.ModelState.IsValid, "This must be valid");
            }
