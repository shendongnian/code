    StackPanel container = new StackPanel();
    LayoutRoot.Children.Add(container);
           
    for (int i = 0; i < listCheckMarks.Count; i++)
    {
       if (listCheckMarks[i].checkMark.Equals(checkMark))
       {
           StackPanel childContainer = new StackPanel();
           childContainer.Orientation = Orientation.Horizontal;
           CheckBox cb = new CheckBox();
           TextBlock cbtextblock = new TextBlock();
           cbtextblock.Text = listCheckMarks[i].Label;
           cbtextblock.Height = 27;
           cbtextblock.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
           cbtextblock.Margin = new Thickness(12, 20, 0, 0);
           cbtextblock.VerticalAlignment = System.Windows.VerticalAlignment.Top;
           cb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
           cb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
           cb.Margin = new Thickness(150, 21, 0, 0);
           cb.Height = 50;
           cb.Width = 100;
           cb.Name = listCheckMarks[i].Name;
          childContainer.Children.Add(cbtextblock);
          childContainer.Children.Add(cb);
          container.Children.Add(childContainer);
      }
    }
