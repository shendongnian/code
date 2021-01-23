    public static class TextBoxBehaviour
    {
        public static bool GetKeepCursorPosition(DependencyObject obj)
        {
            return (bool)obj.GetValue(KeepCursorPositionProperty);
        }
        public static void SetKeepCursorPosition(DependencyObject obj, bool value)
        {
            obj.SetValue(KeepCursorPositionProperty, value);
        }
        // Using a DependencyProperty as the backing store for KeepCursorPosition.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeepCursorPositionProperty =
            DependencyProperty.RegisterAttached("KeepCursorPosition", typeof(bool), typeof(TextBoxBehaviour), new UIPropertyMetadata(false, KeepCursorPosition));
        public static int GetPreviousCaretIndex(DependencyObject obj)
        {
            return (int)obj.GetValue(PreviousCaretIndexProperty);
        }
        public static void SetPreviousCaretIndex(DependencyObject obj, int value)
        {
            obj.SetValue(PreviousCaretIndexProperty, value);
        }
        // Using a DependencyProperty as the backing store for PreviousCaretIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PreviousCaretIndexProperty =
            DependencyProperty.RegisterAttached("PreviousCaretIndex", typeof(int), typeof(TextBoxBehaviour), new UIPropertyMetadata(0));
        public static string GetPreviousTextValue(DependencyObject obj)
        {
            return (string)obj.GetValue(PreviousTextValueProperty);
        }
        public static void SetPreviousTextValue(DependencyObject obj, string value)
        {
            obj.SetValue(PreviousTextValueProperty, value);
        }
        // Using a DependencyProperty as the backing store for PreviousTextValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PreviousTextValueProperty =
            DependencyProperty.RegisterAttached("PreviousTextValue", typeof(string), typeof(TextBoxBehaviour), new UIPropertyMetadata(null));
        private static void KeepCursorPosition(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.SelectionChanged += new RoutedEventHandler(textBox_SelectionChanged);
                textBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(textBox_PreviewKeyDown);
                textBox.TextChanged += new TextChangedEventHandler(textBox_TextChanged);
                textBox.Unloaded += new RoutedEventHandler(textBox_Unloaded);
            }
            else
            {
                throw new ArgumentException("KeepCursorPosition only available for textboxes");
            }
        }
        static void textBox_Unloaded(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.PreviewKeyDown -= new System.Windows.Input.KeyEventHandler(textBox_PreviewKeyDown);
            textBox.TextChanged -= new TextChangedEventHandler(textBox_TextChanged);
            textBox.Unloaded -= new RoutedEventHandler(textBox_Unloaded);
        }
        
        static void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //For some reason our e.Changes only ever contains 1 change of 1 character even if our
            //converter converts it to 2 chars with the additional space - hmmm?
            var textBox = sender as TextBox;
            var previousIndex = GetPreviousCaretIndex(textBox);
            var previousText = GetPreviousTextValue(textBox);
            var previousLen = !String.IsNullOrEmpty(previousText) ? previousText.Length : 0;
            var currentLen = textBox.Text.Length;
            var change = (currentLen - previousLen);
            var newCharIndex = Math.Max(1, (previousIndex + change));
            Debug.WriteLine("Text Changed Previous Caret Pos : {0}", previousIndex);
            Debug.WriteLine("Text Changed Change : {0}", change);
            Debug.WriteLine("Text Changed New Caret Pos : {0}", newCharIndex);
            
            textBox.CaretIndex = Math.Max(newCharIndex, previousIndex);
            SetPreviousCaretIndex(textBox, textBox.CaretIndex);
            SetPreviousTextValue(textBox, textBox.Text);
        }
        static void textBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            Debug.WriteLine("Key Preview Caret Pos : {0}", textBox.CaretIndex);
            Debug.WriteLine("------------------------");
            SetPreviousCaretIndex(textBox, textBox.CaretIndex);
            SetPreviousTextValue(textBox, textBox.Text);
        }
    }
