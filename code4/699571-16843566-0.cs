    for (int i = 0; i < NumofImages; i++)
    {
      Image mole = new Image();
      mole.Source = new BitmapImage(new Uri(MoleImageFunction));
      mole.Name = "Mole" + i;  
      Grid.SetColumn(mole, i);
      grid_Main.Children.Add(mole);
    }
