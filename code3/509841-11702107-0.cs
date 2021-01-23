    >     public MainWindow() {
    >      InitializeComponent();
    >      for (int i = 0; i < 3; i++)
    >      {
    >           for (int j = 0; j < 3; j++)
    >           {
    >                Image Box = new Image();
    >                Grid.SetRow(Box, i);
    >                Grid.SetColumn(Box, j);
    >           }
    >      } 
    >    }
