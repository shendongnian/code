    public class DynamicDisplayNameAttribute : DisplayNameAttribute 
        {
            public DynamicDisplayNameAttribute(string key)
            {
                _key = key;
             }
   
            public override string DisplayName
            {
                get
        {
             //
             //repo database logic to get display name
             //
              string displayName = repo.GetDisplayName(key);
              return string.IsNullOrEmpty(displayName)
                 ?"" 
                 : displayName;
          }
      }
   
      private string _key { get; set; }
