    class MyDataModel
    {
      public MyDataModel()
      {
          LoadFileAsync(); 
      }
      public async void LoadFileAsync()
      {
         // do async operations here 
         var file = await FooAsync(); 
      }
    }
