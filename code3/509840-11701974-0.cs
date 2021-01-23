    for (int i = 0; i < 4; i++)
          {
            for (int j = 0; j < 3; j++)
            {
               Image Box = new Image();
               this.myGrid.Children.Add(Box);
               Grid.SetRow(Box, i);
               Grid.SetColumn(Box, j);
            }
         }
