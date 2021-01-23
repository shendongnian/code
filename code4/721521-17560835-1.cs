        public partial class AnimatedCursorTextBox : UserControl
            {
                private DoubleAnimation cursorAnimation = new DoubleAnimation();
        
                public AnimatedCursorTextBox()
                {
                    InitializeComponent();
                }
        
                private void UpdateCaretPosition()
                {
                    var rectangle = MainTextBox.GetRectFromCharacterIndex(MainTextBox.CaretIndex);
                    Caret.Height = rectangle.Bottom - rectangle.Top;
                    Canvas.SetTop(Caret, rectangle.Top);
                    Canvas.SetBottom(Caret, rectangle.Bottom);
                    var left = Canvas.GetLeft(Caret);
                    if (!double.IsNaN(left))
                    {
                        cursorAnimation.From = left;
                        cursorAnimation.To = rectangle.Right;
                        cursorAnimation.Duration = new Duration(TimeSpan.FromSeconds(.05));
                        Caret.BeginAnimation(Canvas.LeftProperty, cursorAnimation);
                    }
                    else
                    {
                        Canvas.SetLeft(Caret, rectangle.Right);
                    }
                }
        
                private void MainTextBox_SelectionChanged(object sender, RoutedEventArgs e)
                {
                    UpdateCaretPosition();
                }
        
                private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
                {
                    UpdateCaretPosition();
                }
                private void MainTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
                {
                    UpdateCaretPosition();
                }
            }
