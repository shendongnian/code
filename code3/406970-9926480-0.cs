    public sealed class TextBoxBehaviour : DependencyObject
    {
        #region CoerceValue Attached property
        public static bool GetCoerceValue(DependencyObject obj)
        {
            return (bool)obj.GetValue(CoerceValueProperty);
        }
        public static void SetCoerceValue(DependencyObject obj, bool value)
        {
            obj.SetValue(CoerceValueProperty, value);
        }
        /// <summary>
        /// Gets or Sets whether the TextBox should reevaluate the binding after it pushes a change (either on LostFocus or PropertyChanged depending on the binding).
        /// </summary>
        public static readonly DependencyProperty CoerceValueProperty =
            DependencyProperty.RegisterAttached("CoerceValue", typeof(bool), typeof(TextBoxBehaviour), new UIPropertyMetadata(false, CoerceValuePropertyChanged));
        static void CoerceValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textbox = d as TextBox;
            if (textbox == null) 
                return;
            if ((bool)e.NewValue)
            {
                if (textbox.IsLoaded)
                {
                    PrepareTextBox(textbox);
                }
                else
                {
                    textbox.Loaded += OnTextBoxLoaded;
                }
            }
            else
            {
                textbox.TextChanged -= OnCoerceText;
                textbox.LostFocus-= OnCoerceText;
                textbox.Loaded -= OnTextBoxLoaded;
            }
        }
        static void OnTextBoxLoaded(object sender, RoutedEventArgs e)
        {
            var textbox = (TextBox)sender;
            PrepareTextBox(textbox);
            textbox.Loaded -= OnTextBoxLoaded;
        }
        static void OnCoerceText(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var selectionStart = textBox.SelectionStart;
            var selectionLength = textBox.SelectionLength;
            textBox.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            if (selectionStart < textBox.Text.Length) textBox.SelectionStart = selectionStart;
            if (selectionStart + selectionLength < textBox.Text.Length) textBox.SelectionLength = selectionLength;
        }
        private static void PrepareTextBox(TextBox textbox)
        {
            var binding = textbox.GetBindingExpression(TextBox.TextProperty).ParentBinding;
            var newBinding = binding.Clone();
            newBinding.ValidatesOnDataErrors = true;
            textbox.SetBinding(TextBox.TextProperty, newBinding);
            if (newBinding.UpdateSourceTrigger == UpdateSourceTrigger.PropertyChanged)
            {
                textbox.TextChanged += OnCoerceText;
            }
            else if (newBinding.UpdateSourceTrigger == UpdateSourceTrigger.LostFocus || newBinding.UpdateSourceTrigger == UpdateSourceTrigger.Default)
            {
                textbox.LostFocus += OnCoerceText;
            }
        }
        #endregion
    }
