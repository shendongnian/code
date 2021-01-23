    if (this.ApplicationBar.Buttons.Count > index)
                {
                    button1 = this.ApplicationBar.Buttons[index] as ApplicationBarIconButton;
    
                    this.ApplicationBar.Buttons.Remove(button1);
    
                    if (visibility == true)
                    {
                        button1 = new ApplicationBarIconButton(new Uri(uriString, UriKind.RelativeOrAbsolute));
                        button1.Text = text;
                        button1.Click += handler;
                        this.ApplicationBar.Buttons.Insert(index, button1);
                    }
                }
    
                else
                // insert it anyway?
                {
                    if (visibility == true)
                    {
                        button1 = new ApplicationBarIconButton(new Uri(uriString, UriKind.RelativeOrAbsolute));
                        button1.Text = text;
                        button1.Click += handler;
                        this.ApplicationBar.Buttons.Add(button1);
                    }
                }
