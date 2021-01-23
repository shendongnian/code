     private int _previousLine;
        public int PreviousLine
        {
            get { return _previousLine; }
            set { _previousLine = value;
                Line = _previousLine + 5;
            }
        }
        public int Line { get; private set; }
