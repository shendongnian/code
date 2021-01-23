      public class Foo
      {
        [RegistrationDisplayNameAttribute("MyProp2")]
        public string MyProp { get; set; }
    
        public string MyProp2 { get; set; }
    
    
        public Foo()
        {
          var atts = this.GetType().GetCustomAttributes();
          foreach (var item in atts)
          {
            if (atts is RegistrationDisplayNameAttribute)
            {
              ((RegistrationDisplayNameAttribute)atts).Instance = this;
            }
          }
        }
      }
