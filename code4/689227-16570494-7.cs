     public class SquaresGameViewModel: PropertyChangedBase
        {
            private ObservableCollection<Square> _squares;
            public ObservableCollection<Square> Squares
            {
                get { return _squares ?? (_squares = new ObservableCollection<Square>()); }
            }
    
            private int _rows;
            public int Rows
            {
                get { return _rows; }
                set
                {
                    _rows = value;
                    OnPropertyChanged("Rows");
                    CreateSquares();
                }
            }
    
            private int _columns;
            public int Columns
            {
                get { return _columns; }
                set
                {
                    _columns = value;
                    OnPropertyChanged("Columns");
                    CreateSquares();
                }
            }
    
            public List<int> Numbers { get; set; }
    
            public SquaresGameViewModel()
            {
                _rows = 10;
                _columns = 10;
                Numbers = Enumerable.Range(1, 20).ToList();
                CreateSquares();
            }
    
            private void CreateSquares()
            {
                Squares.Clear();
    
                Enumerable.Range(0, Rows)
                          .SelectMany(x => Enumerable.Range(0, Columns)
                                                     .Select(y => new Square { Row = x, Column = y }))
                          .ToList().ForEach(Squares.Add);
            }
        }
