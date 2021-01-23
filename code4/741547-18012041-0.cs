    #region IsNumericOnly
    /// <summary>
    /// Provides the ability to restrict the text input of the TextBox control to only allow numeric values to be entered.
    /// </summary>
    public static readonly DependencyProperty IsNumericOnlyProperty = DependencyProperty.RegisterAttached("IsNumericOnly", typeof(bool), typeof(TextBoxProperties), new UIPropertyMetadata(default(bool), OnIsNumericOnlyChanged));
    /// <summary>
    /// Gets the value of the IsNumericOnly property.
    /// </summary>
    /// <param name="dependencyObject">The DependencyObject to return the IsNumericOnly property value from.</param>
    /// <returns>The value of the IsNumericOnly property.</returns>
    public static bool GetIsNumericOnly(DependencyObject dependencyObject)
    {
        return (bool)dependencyObject.GetValue(IsNumericOnlyProperty);
    }
    /// <summary>
    /// Sets the value of the IsNumericOnly property.
    /// </summary>
    /// <param name="dependencyObject">The DependencyObject to set the IsNumericOnly property value of.</param>
    /// <param name="value">The value to be assigned to the IsNumericOnly property.</param>
    public static void SetIsNumericOnly(DependencyObject dependencyObject, bool value)
    {
        dependencyObject.SetValue(IsNumericOnlyProperty, value);
    }
    /// <summary>
    /// Adds key listening event handlers to the TextBox object to prevent non numeric key strokes from being accepted if the IsNumericOnly property value is true, or removes them otherwise.
    /// </summary>
    /// <param name="dependencyObject">The TextBox object.</param>
    /// <param name="dependencyPropertyChangedEventArgs">The DependencyPropertyChangedEventArgs object containing event specific information.</param>
    public static void OnIsNumericOnlyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        TextBox textBox = dependencyObject as TextBox;
        if (textBox != null)
        {
            bool newIsNumericOnlyValue = (bool)dependencyPropertyChangedEventArgs.NewValue;
            TextCompositionEventHandler textBox_PreviewTextInput = new TextCompositionEventHandler((s, e) => e.Handled = !e.Text.All(c => Char.IsNumber(c) && c != ' '));
            KeyEventHandler textBox_PreviewKeyDown = new KeyEventHandler((s, e) => e.Handled = e.Key == Key.Space);
            if (newIsNumericOnlyValue)
            {
                textBox.PreviewTextInput += textBox_PreviewTextInput;
                textBox.PreviewKeyDown += textBox_PreviewKeyDown;
            }
            else
            {
                textBox.PreviewTextInput -= textBox_PreviewTextInput;
                textBox.PreviewKeyDown -= textBox_PreviewKeyDown;
            }
        }
    }
    #endregion
