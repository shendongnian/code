      private void wpContainer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Button newButton = new Button()
                             {
                                 Content= wpContainer.Children.Count,
 
                                 Margin = new Thickness()
                                 {
                                     Right = 10,
 
                                     Left = 10,
                                 }
                             };
 
            var mousePosition = Mouse.GetPosition(wpContainer);
 
            int index=0;
 
            foreach (var child in wpContainer.Children)
            {
                Button currentButton = (child as Button);
 
                if (currentButton==null)
                    continue;
 
                Point buttonPosition = currentButton.TransformToAncestor(wpContainer).Transform(new Point(0, 0));
 
                if (buttonPosition.X  > mousePosition.X && buttonPosition.Y+currentButton.ActualHeight > mousePosition.Y)
                {
                    wpContainer.Children.Insert(index, newButton);
                    
                    return;                    
                }
 
                index++;
            }
 
            if(wpContainer.Children.Count==0 || index==wpContainer.Children.Count) //no items where detected so add it to the end of the Children
                wpContainer.Children.Add(newButton);
        }
