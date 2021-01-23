        private GetStartedModel()
        {}
        public static async Task<GetStartedModel> Create()
        {
            var service = new TestDataWebServiceHelper();
            var result = new GetStartedModel();
            listA = await result.SetListA(service);
            listB = await result.SetListB(service);
            return result;
        }
