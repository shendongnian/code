        public class ChessPiece: INotifyPropertyChanged
        {
            public bool IsBlack { get; set; }
    
            public ChessPieceTypes Type { get; set; }
    
    
            private int _row;
            public int Row
            {
                get { return _row; }
                set
                {
                    _row = value;
                    OnPropertyChanged("Row");
                }
            }
    
            private int _column;
            public int Column
            {
                get { return _column; }
                set
                {
                    _column = value;
                    OnPropertyChanged("Column");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public string ImageSource 
            {
                get { return "../ChessPieces/" + (IsBlack ? "Black" : "White") + Type.ToString() + ".png"; }
            }
        }
    
        public enum ChessPieceTypes
        {
            Pawn,
            Tower,
            Knight,
            Bishop,
            Queen,
            King,
        }
    }
