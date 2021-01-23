    class ConsoleColumnFormatter {
        private int _columnWidth = 20;
        private int _numColumns = 4;
        private int _currentColumn = 1;
        public ConsoleColumnFormatter(int numColumns, int columnWidth) {
            _numColumns = numColumns;
            _columnWidth = columnWidth;
        }
        public void Write(string str) {
            Console.Write(str.PadRight(_columnWidth - str.Length, ' '));
            _currentColumn++;
            checkForNewLine();
        }
        private void checkForNewLine() {
            if (_currentColumn >= _numColumns) {
                Console.Write("\n");
                _currentColumn = 1;
            }
        }
    }
