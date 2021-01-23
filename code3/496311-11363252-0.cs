    class MyViewModel
    {
       public MyViewModel(MyModel model)
       {
          this.Name = model.Name;
          this.Colour = model.Colour;
       }
    
       public string Name {get;set;}
       public string Colour {get;set;}
    
       // commands here that connect to the following methods
    
       public void Save()
       {
          model.Name = this.Name;
          model.Colour = this.Colour;
          model.SaveToDatabase();
       }
    
       public void Cancel()
       {
          this.Name = model.Name;
          this.Colour = model.Colour;
       }
    
    }
