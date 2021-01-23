      protected void Application_Start()
      {
         var serializerSettings = new JsonSerializerSettings();
         serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
         serializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
         var serializer = JsonSerializer.Create(serializerSettings);
         GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => serializer); 
      }
