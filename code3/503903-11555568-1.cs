        [Test]
        public void Test1()
        {
            var mockRepository = new MockRepository();
            var test = mockRepository.StrictMock<ITest>();
            var dictionary = new CustomDictionary { { "Test", "Test1" } };
            using (mockRepository.Record())            
                Expect.Call(() => test.DoSth(dictionary));
            
            test.DoSth(dictionary);
            mockRepository.VerifyAll();
        }
 
