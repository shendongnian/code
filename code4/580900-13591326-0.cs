    Grid grid =   (((Button)sender).Parent) as Grid;
    if(grid != null)
    {
       ListBox listbox = grid.Parent as ListBox;
       if(listbox != null)
       {
         listbox.Children.Remove(grid);
       }
    }
