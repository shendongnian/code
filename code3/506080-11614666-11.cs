    [JsonFilter(Parameter = "model", JsonDataType = typeof(UserArgLevelModel), Settings = new JsonSerializerSettings { ContractResolver = new SnakeCasePropertyNamesContractResolver() })]
    public ActionResult UpdateArgLevel(UserArgLevelModel model) {
    {
        // model is deserialized correctly!
    }
