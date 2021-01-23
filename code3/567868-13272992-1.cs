    private readonly List<string> _items;
    public MyStackPanel(List<string> items) 
    {
        _items = items;
        var behavior = new MyBehavior();
        behavior.SetBinding(MyBehavior.ShowDetailsCommandProperty, new Binding
        {
            Path = new PropertyPath("ShowDetailsCommand")
        });
        Interaction.GetBehaviors(this).Add(behavior);
    }
    public void FillInData() 
    {
         foreach (string item in _items)
         {         
             var block = new Button();
             block.Click += ItemClick;
             this.Children.Add(block);
         }
    }
