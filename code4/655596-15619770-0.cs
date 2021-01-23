    [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
     ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
    public void SaveLabResults(List<MyEntity> myEntity, SomeObject secondParameter)
    {
          var lstEntities=myEntity;
    }
