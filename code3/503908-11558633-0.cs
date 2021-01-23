            using (mockRepository.Record())
            {
                Expect.Call(() => test.DoSth(new CustomDictionary { { "Test", "Test1" } }));
            }
            test.DoSth(new CustomDictionary { { "Test", "Test1" } });
