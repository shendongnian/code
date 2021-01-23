        private GetStartedModel()
        {}
        public static async Task Create()
        {
            var service = new TestDataWebServiceHelper();
            var result = new GetStartedModel();
            listA = await result.SetListA(service);
            listB = await result.SetListB(service);
        }
