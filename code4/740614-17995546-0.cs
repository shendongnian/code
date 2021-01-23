    public class RetrieveAnonymousTypeFromTheWebInCSharp 
        : BehaviorTest
    {
        private object _testModel;
        private HttpResponseMessage _message;
        protected override void Given()
        {
            _testModel = new
                {
                    Id = 14,
                    MyProperty = "Test property value"
                };
        }
        protected override void When()
        {
            _message = new HttpResponseMessage(HttpStatusCode.Accepted)
                           {
                               Content =
                                   new ObjectContent(_testModel.GetType(),
                                                     _testModel,
                                                     new JsonMediaTypeFormatter
                                                         ())
                           };
        }
        [Test]
        public void Then()
        {
            //then properties could be retrieved back by dynamics
            dynamic content = _message.Content.ReadAsAsync<ExpandoObject>().Result;
            var propertyvalue = content.MyProperty;
            Assert.That(propertyvalue, Is.Not.Null.And.EqualTo("Test property value"));
        }
    }
