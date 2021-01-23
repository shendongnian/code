    public class ClientKeyboardController : DependencyObject
    {
        /// <summary>
        /// <para>
        /// Set this property to true to enable the focus based keyboard popup functionality.
        /// This will request the client device show it's on-screen keyboard whenever the text
        /// box gets focus.
        /// </para>
        /// <para>
        /// Note: to hide the keyboard, either enable the AutoHideKeyboard dependency property
        /// as well, or manually hide the keyboard at an appropriate time.
        /// </para>
        /// </summary>
        public static readonly DependencyProperty AutoShowKeyboardProperty = DependencyProperty.RegisterAttached(
            "AutoShowKeyboard",
            typeof(bool),
            typeof(ClientKeyboardController),
            new PropertyMetadata(false, AutoShowKeyboardPropertyChanged));
        /// <summary>
        /// <see cref="AutoShowKeyboardProperty"/> getter.
        /// </summary>
        /// <param name="obj">The dependency object to get the value from.</param>
        /// <returns>Gets the value of the auto show keyboard attached property.</returns>
        [AttachedPropertyBrowsableForChildrenAttribute(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
        public static bool GetAutoShowKeyboard(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoShowKeyboardProperty);
        }
        /// <summary>
        /// <see cref="AutoShowKeyboardProperty"/> setter.
        /// </summary>
        /// <param name="obj">The dependency object to set the value on.</param>
        /// <param name="value">The value to set.</param>
        public static void SetAutoShowKeyboard(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoShowKeyboardProperty, value);
        }
        /// <summary>
        /// Set this property to true to enable the focus based keyboard hide functionality.
        /// This will request the client device to hide it's on-screen keyboard whenever the
        /// text box loses focus.
        /// </summary>
        public static readonly DependencyProperty AutoHideKeyboardProperty = DependencyProperty.RegisterAttached(
            "AutoHideKeyboard",
            typeof(bool),
            typeof(ClientKeyboardController),
            new PropertyMetadata(false, AutoHideKeyboardPropertyChanged));
        /// <summary>
        /// AutoHideKeyboard getter
        /// </summary>
        /// <param name="obj">The dependency object we want the value from.</param>
        /// <returns>Gets the value of the auto hide keyboard attached property.</returns>
        [AttachedPropertyBrowsableForChildrenAttribute(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
        public static bool GetAutoHideKeyboard(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoHideKeyboardProperty);
        }
        /// <summary>
        /// AutoHideKeyboard setter.
        /// </summary>
        /// <param name="obj">The dependency object to set the value on.</param>
        /// <param name="value">The value to set.</param>
        public static void SetAutoHideKeyboard(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoHideKeyboardProperty, value);
        }
        /// <summary>
        /// Handler for the AutoShowKeyboard dependency property being changed.
        /// </summary>
        /// <param name="d">Object the property is applied to.</param>
        /// <param name="e">Change args</param>
        private static void AutoShowKeyboardPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBoxBase textBox = d as TextBoxBase;
            if (null != textBox)
            {
                if ((e.NewValue as bool?).GetValueOrDefault(false))
                {
                    textBox.GotKeyboardFocus += OnGotKeyboardFocus;
                    textBox.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
                }
                else
                {
                    textBox.GotKeyboardFocus -= OnGotKeyboardFocus;
                    textBox.PreviewMouseLeftButtonDown -= OnMouseLeftButtonDown;
                }
            }
        }
        /// <summary>
        /// Handler for the AutoHideKeyboard dependency property being changed.
        /// </summary>
        /// <param name="d">Object the property is applied to.</param>
        /// <param name="e">Change args</param>
        private static void AutoHideKeyboardPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBoxBase textBox = d as TextBoxBase;
            if (null != textBox)
            {
                if ((e.NewValue as bool?).GetValueOrDefault(false))
                {
                    textBox.LostKeyboardFocus += OnLostKeyboardFocus;
                }
                else
                {
                    textBox.LostKeyboardFocus -= OnLostKeyboardFocus;
                }
            }
        }
        /// <summary>
        /// Left click handler. We handle left clicks to ensure the text box gets focus, and if
        /// it already has focus we reshow the keyboard. This means a user can reshow the
        /// keyboard when the text box already has focus, i.e. they don't have to swap focus to
        /// another control and then back to the text box.
        /// </summary>
        /// <param name="sender">The text box that was clicked on.</param>
        /// <param name="e">The left mouse click event arguments.</param>
        private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBoxBase textBox = sender as TextBoxBase;
            if (null != textBox)
            {
                if (textBox.IsKeyboardFocusWithin)
                {
                    // TODO: Show on-screen keyboard
                }
                else
                {
                    // Ensure focus is set to the text box - the focus handler will then show the
                    // keyboard.
                    textBox.Focus();
                    e.Handled = true;
                }
            }
        }
        /// <summary>
        /// Got focus handler. Displays the client keyboard.
        /// </summary>
        /// <param name="sender">The text box that received keyboard focus.</param>
        /// <param name="e">The got focus event arguments.</param>
        private static void OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBoxBase textBox = e.OriginalSource as TextBoxBase;
            if (textBox != null)
            {
                // TODO: Show on-screen keyboard
            }
        }
        /// <summary>
        /// Lost focus handler. Hides the client keyboard. However we skip hiding if the new
        /// element that gains focus has got the auto-show keyboard attached property set to
        /// true. This prevents screen glitching from quickly showing/hiding the keyboard.
        /// </summary>
        /// <param name="sender">The text box that lost keyboard focus.</param>
        /// <param name="e">The lost focus event arguments.</param>
        private static void OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBoxBase textBox = e.OriginalSource as TextBoxBase;
            if (textBox != null)
            {
                bool skipHide = false;
                if (e.NewFocus is DependencyObject)
                {
                    skipHide = GetAutoShowKeyboard(e.NewFocus as DependencyObject);
                }
                if (!skipHide && ClientKeyboardController.CmpInput != null)
                {
                    // TODO: Hide on-screen keyboard.
                }
            }
        }
    }
