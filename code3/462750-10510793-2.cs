     List<ItemVM> Items;
                   List<string> lst = new List<string> {"item1","item2","item3" };
                   var converter = new System.Windows.Media.BrushConverter();
      Color[] colors = ColorHelper.CreateRandomColors(3);
      Items = new List<ItemVM>();
     for(int i=0;i<lst.count;i++)
     {
     Items.Add(new ItemVM((Brush)converter.ConvertFromString(colors[i].ToString()), SelectedItems[i]));
    }
     plotter.LegendVisible = false;
     listview.ItemsSource = Items;
