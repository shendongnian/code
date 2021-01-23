    private void VisibilityManager(Grid grd)
    {
        new List<Grid>(){ panel1, panel2, panel3}
           .ForEach(x => x.Visibility = Visibility.Hidden);
        grd.Visibility = Visibility.Visible;
    }
