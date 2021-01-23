    [WebMethod]
    public static string GetJsonData()
    {
              List<A> objA = new List<A>();
              A objAItem = new A();
              foreach (var dbItem in objDataBaseValues)
              {
                    objA.prop1 = "test";
                    B objBItem = new B();
                    b.prop2="value";
                    b.prop3="value";
                    objA.Values.Add(objBItem);
              }
            return new JavaScriptSerializer().Serialize(objA);
            
      }
