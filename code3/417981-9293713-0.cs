      System.Windows.Controls.Button newBtn = new Button();
      Image imageControl = new Image();
      imageControl.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), tbButtonPicture));
      newBtn.Content = imageControl;
      newBtn.Name = "Button" + i.ToString();
      sp.Children.Add(newBtn);
    
      i++;
