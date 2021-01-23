    public static class MyExtensions
    {
        public static MyCustomModel ConvertToMyCustomModel(this MyCustomModel model, WebServiceModel wsModel)
        {
            var newModel = new MyCustomModel { Id = wsModel.Id, SomeValue = wsModel.SomeValue };
            return newModel;
        }
    }
