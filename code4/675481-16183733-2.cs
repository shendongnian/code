        class MyCustomIdentity : GenericIdentity
        {
          public string[] UserData { get; set;}
          public MyCustomIdentity(string a, string b) : base(a,b)
          {
          }
        }
