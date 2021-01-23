    for(YourObject obj : ar)
    {
      System.Windows.Controls.Button newBtn = new Button();
      newBtn.Content = obj.YourProperty;
      newBtn.Name = "Button" + obj.YourProperty;
      sp.Children.Add(newBtn);
    }
