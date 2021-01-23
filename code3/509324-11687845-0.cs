        for (int i = 0; i < wrapWidthItems; i++)
        {
            for (int j = 0; j < wrapHeightItems; j++)
            {
                Button bnt = new Button();
                bnt.Width = 50;
                bnt.Height = 50;
                bnt.Content = "Button" + i + j;
                bnt.Name = "Button" + i + j;
                bnt.Click += new RoutedEventHandler(bnt_Click);
               /* bnt.Click += (source, e) =>
                {
                    MessageBox.Show("Button pressed" + bnt.Name);
                };*/
                wrapPanelCategoryButtons.Children.Add(bnt);
            }
        }
    }
    void bnt_Click(object sender, RoutedEventArgs e)
    {
        
        Button buttonThatWasClicked = (Button)sender;
        MessageBox.Show("Button pressed " + buttonThatWasClicked.Name);
        
    }
