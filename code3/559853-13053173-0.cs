    <TextBox Text="{Binding ConsoleContents, Mode=OneWay}" 
             TextWrapping="Wrap" IsReadOnly="True" ScrollViewer.VerticalScrollBarVisibility="Visible" TextChanged="TextBox_TextChanged" 
             MouseEnter="TextBox_MouseEnterLeave" MouseLeave="TextBox_MouseEnterLeave" SelectionChanged="TextBox_SelectionChanged" AllowDrop="False" Focusable="True" 
             IsUndoEnabled="False"></TextBox>
---
    public partial class ConsoleView : UserControl
    {
        private bool _canScroll;
        // saves
        private int _selectionStart;
        private int _selectionLength;
        private string _selectedText;
        public ConsoleView(ConsoleViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            _canScroll = true;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;
            // ensure we can scroll
            if (_canScroll)
            {
                // set the cursor to the end and scroll down
                textBox.Select(textBox.Text.Length, 0);
                textBox.ScrollToEnd();
                // save these so the box doesn't jump around if the user goes back in
                _selectionLength = textBox.SelectionLength;
                _selectionStart = textBox.SelectionStart;
            }
            else if (!_canScroll)
            {
                // move the cursor to where the mouse is if we're not selecting anything (for if we are selecting something the cursor has already moved to where it needs to be)
                if (string.IsNullOrEmpty(_selectedText))
                //if (textBox.SelectionLength > 0)
                {
                    textBox.CaretIndex = textBox.GetCharacterIndexFromPoint(Mouse.GetPosition(textBox), true);
                }
                else
                {
                    textBox.Select(_selectionStart, _selectionLength); // restore what was saved
                }
            }
        }
        private void TextBox_MouseEnterLeave(object sender, MouseEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;
            // Don't scroll if the mouse is in the box
            if (e.RoutedEvent.Name == "MouseEnter")
            {
                _canScroll = false;
            }
            else if (e.RoutedEvent.Name == "MouseLeave")
            {
                _canScroll = true;
            }
        }
        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;
            // save all of the things
            _selectionLength = textBox.SelectionLength;
            _selectionStart = textBox.SelectionStart;
            _selectedText = textBox.SelectedText; // save the selected text because it gets destroyed on text update before the TexChanged event.
        }
    }
