     private static HelpPageApiModel GenerateApiModel(ApiDescription apiDescription, HelpPageSampleGenerator sampleGenerator)
        {
            HelpPageApiModel apiModel = new HelpPageApiModel();
            apiModel.ApiDescription = apiDescription;
            HttpActionDescriptor currentActionDescriptor = apiDescription.ActionDescriptor;
            IEnumerable<HttpParameterDescriptor> currentActionParamDescriptors = ad.GetParameters();
