    someMethod()
    {
      TestHelper.TryValidate(model); // TestHelper is another class where validation is being done
      if(model.IsValid)
      {
          return true;
      }
      else
      {
        return false;
      }
        
    }
