    [POST("{primaryEntity}", RouteName = "PostPrimary")]
    public async Task<HttpResponseMessage> CreatePrimary(string primaryEntity, JObject entity)
    {
       // first find out which params are necessary to accept the request based on the entity's mapped metadata type
       OperationalParams paramsForRequest = GetOperationalParams(primaryEntity, DatasetOperationalEntityIntentIntentType.POST);
    
       // map the passed values to the expected params and the intent that is in use
       IDictionary<string, object> objValues = MapAndValidateProperties(paramsForRequest.EntityModel, paramsForRequest.IntentModel, entity);
    
       // get the results back from the service and return the data to the client.
       QueryResults results = await paramsForRequest.ClientService.CreatePrimaryEntity(paramsForRequest.EntityModel, objValues, entity, paramsForRequest.IntentModel);
            return HttpResponseMessageFromQueryResults(primaryEntity, results);
    
    }
