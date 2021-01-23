      [WebMethod]
      public string GetMessage()
      {
            Messageformat msgFrmt = new Messageformat();
            msgFrmt.AtrributeCollection = new Atrributecollection()
                                             { 
                                                 name="test",
                                                 id=1
                                             };
            msgFrmt.Input = new Input()
                                {
                                   soid= "soid value",
                                   itemname="item",
                                   qty=10
                                };
      }
