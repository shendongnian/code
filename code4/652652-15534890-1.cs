    for (int i = 1; i < 6;  ++i)
    {
        Button btn = new Button();
        btn.Margin= new Thickness(4,4,4,4);
        grd.Children.Add(btn);
        btn.SetValue(Grid.RowProperty, j);
        btn.SetValue(Grid.ColumnProperty, i);
        btn.Tag = "The filename for this buttons image";
    }
