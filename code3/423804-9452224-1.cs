    class Cat
    {
       [DisplayName("Cats Name")]
       public string Name {get;set;}
       public string Likes {get; set;}
    }
    ...
    public void BindCatsToGrid(List<Cat> cats)
    {
        bindingDataSource = new BindingDataSource();
        bindingDataSource.DataSource = cats;
        grid.DataSource = bindingDataSource;
    }
