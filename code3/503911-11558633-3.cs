            var myDictionary = new CustomDictionary { { "Test", "Test1" } }));
            using (mockRepository.Record())
            {
                Expect.Call(() => test.DoSth(myDictionary);
            }
            test.DoSth(myDictionary );
