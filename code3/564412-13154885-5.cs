    public WrappedSquare
    {
       Square _saure;
       SquareViewModel _square;
    
       public WrappedSquare(Square square, SquareViewModel parent)
       {
           /* assignment */
       }
    
       public ICommand TheCommand { get { return MvxRelayCommand(() -> _parent.DoStuff(_square)); } }
       public Square TheSquare { get { return _square; } } 
    }
