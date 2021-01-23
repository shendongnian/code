         private string _foo = "fooValue";
         public string Foo
         {
             get { return _foo; }
             set { _foo = value; }
         }
         public void Test()
         {
             PropertyInfo pi = this.GetType().GetProperty("Foo");
             string v = (string)pi.GetValue(this, null);
         }
