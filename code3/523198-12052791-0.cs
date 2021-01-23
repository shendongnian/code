     [WebBrowsable(true), 
      Category("category"), 
      Personalizable(PersonalizationScope.Shared), 
      WebDisplayName("Hello"), 
      WebDescription("Description1"),
      WebPartStorage(Storage.Shared)] 
      public string hello 
      { 
          get { return _hello; } 
          set { _hello = value; } 
      } 
      public static string _hello; 
