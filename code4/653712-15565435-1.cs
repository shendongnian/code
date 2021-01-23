        [Test]
        public void Test_UnboxingAtRuntime()
        {
            object boxed = "Hello";
            //this line is commented out as it does not compile
            // OverloadedMethod(boxed);
            var result = CallCorrectMethod(boxed);
            Assert.That(result, Is.EqualTo("string"));
            boxed = 1;
            result = CallCorrectMethod(boxed);
            Assert.That(result, Is.EqualTo("int"));
        }
        public string CallCorrectMethod(dynamic t)
        {
            return OverloadedMethod(t);
        }
        public string OverloadedMethod(string s)
        {
            return "string";
        }
        public string OverloadedMethod(int s)
        {
            return "int";
        }
