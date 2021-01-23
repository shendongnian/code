    //C#
    class MyData
    {
      public strig DogName{ get; set; }
      public strig CatName{ get; set; }
    }
    this.DataContext = new MyData{ DogName = "Lulu", CatName = "Fifi" };
    
    //xaml
    <Label Content="{Binding Path=DogName}"/>
    <Label Content="{Binding Path=CatName}"/>
