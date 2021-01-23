    public class ButtonClickedEventArgs : EventArgs
    {
        public ButtonClickedEventArgs(TicTacToeUserControl userControl, Button button,
                                      int buttonNumber, int row, int column)
        {
            UserControl = userControl;
            Button = button;
            ButtonNumber = buttonNumber;
            Row = row;
            Column = column;
        }
        public TicTacToeUserControl UserControl { get; private set; }
        public Button Button { get; private set; }
        public int ButtonNumber { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }
    }
