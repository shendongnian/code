     Random random = new Random();
    
            public GridSample() //Window Constructor
            {
                InitializeComponent();
    
                var names = new[] {"NORTH","SOUTH","EAST","WEST"};
    
    
                DataContext = names.Select(x => new GridViewModel()
                                                    {
                                                        Name = x,
                                                        Epic = CreateRandomCell(),
                                                        Lancair = CreateRandomCell(),
                                                        Pitts = CreateRandomCell(),
                                                        Vans = CreateRandomCell()
                                                    });
            }
    
            private CellViewModel CreateRandomCell()
            {
                return new CellViewModel
                           {
                               Name = "Cell" + random.Next(0, 100),
                               ImageSource = "/ChessPieces/BlackBishop.png",
                               Value = (decimal) random.Next(0, 100)
                           };
            }
