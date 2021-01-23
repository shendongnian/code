            Border gridBorder = new Border();
            gridBorder.BorderBrush = new SolidColorBrush(Colors.Black);
            gridBorder.BorderThickness = new Thickness(4);
            gridBorder.Child = new Grid(); //Your grid here
            LayoutRoot.Children.Add(border); // ParentGrid(layout) holding the border
