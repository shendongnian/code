    private void InitializeUniformGrid()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                _uniformGrid.Children.Add(new Rectangle { Fill = Brushes.Black, Stroke = Brushes.Black });
                _uniformGrid.Children.Add(new Rectangle { Fill = Brushes.White, Stroke = Brushes.Black });
            }
            for (int k = 0; k < 4; k++)
            {
                _uniformGrid.Children.Add(new Rectangle { Fill = Brushes.White, Stroke = Brushes.Black });
                _uniformGrid.Children.Add(new Rectangle { Fill = Brushes.Black, Stroke = Brushes.Black });
            }
        }
    }
