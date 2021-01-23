       [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public void SaveLabResults(List<MyEntity> myEntity,List<MyEntity> myEntity2)
        {
              var lstEntities=myEntity;
              var lstEntities2=myEntity2;
        }
