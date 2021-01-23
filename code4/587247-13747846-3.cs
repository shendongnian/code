    [DefaultEvent("ButtonClicked")]
    public partial class TicTacToeUserControl : UserControl
    {
        public event EventHandler<ButtonClickedEventArgs> ButtonClicked;
        public TicTacToeUserControl()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            OnButtonClicked((Button)sender);
        }
        private void OnButtonClicked(Button button)
        {
            var eh = ButtonClicked;
            if (eh != null) {
                int buttonNumber =
                    Int32.Parse(button.Name.Substring(button.Name.Length - 1));
                int row = (buttonNumber - 1) / 3;
                int col = (buttonNumber - 1) % 3;
                eh(this, 
                   new ButtonClickedEventArgs(this, button, buttonNumber, row, col));
            }
        }
    }
