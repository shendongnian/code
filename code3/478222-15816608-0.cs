    private void Login_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       string piName = (e.AddedItems[0] as PanoramaItem).Name;
    
       switch(piName)
       {
          case "piLogin":
             SetupAppBar_Signin();
             break;
          case "piRegister":
             SetupAppBar_Register();
             break;
       }
    }
    
    //use this code only if you need to setup the app bar from code
    void SetupAppBar()
    {
       ApplicationBar = new ApplicationBar();
    
       ApplicationBar.Mode = ApplicationBarMode.Default;
       ApplicationBar.Opacity = 1.0;
       ApplicationBar.IsVisible = true;
       ApplicationBar.IsMenuEnabled = true;
    }
    
    
    void SetupAppBar_Signin()
    {   
       ApplicationBar.Buttons.Clear();
    
       ApplicationBarIconButton button1 = new ApplicationBarIconButton();
       button1.IconUri = new Uri("/icon.png", UriKind.Relative);
       button1.Text = "button 1";
       ApplicationBar.Buttons.Add(button1);
       button1.Click += new EventHandler(button1_Click);
    }
    
    void SetupAppBar_Register()
    {   
       ApplicationBar.Buttons.Clear();
    
       ApplicationBarIconButton button1 = new ApplicationBarIconButton();
       button1.IconUri = new Uri("/icon.png", UriKind.Relative);
       button1.Text = "button 1";
       ApplicationBar.Buttons.Add(button1);
       button1.Click += new EventHandler(button1_Click);
    
       ApplicationBarIconButton button2 = new ApplicationBarIconButton();
       button2.IconUri = new Uri("/icon.png", UriKind.Relative);
       button2.Text = "button 1";
       ApplicationBar.Buttons.Add(button2);
       button2.Click += new EventHandler(button2_Click);
    }
