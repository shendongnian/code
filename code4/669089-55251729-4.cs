    public class ComboBoxClearBehavior : Behavior<ComboBox>
    {
        private Button _addedButton;
        private ContentPresenter _presenter;
        private Thickness _originalPresenterMargins;
        protected override void OnAttached()
        {
            // Attach to the Loaded event. The visual tree at this point is not available until its loaded.
            AssociatedObject.Loaded += AssociatedObject_Loaded;
            // If the user or code changes the selection, re-evaluate if we should show the clear button
            AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
            base.OnAttached();
        }
        protected override void OnDetaching()
        {
            // Its likely that this is already de-referenced, but just in case the visual was never loaded, we will remove the handler anyways.
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
            base.OnDetaching();
        }
        private void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EvaluateDisplay();
        }
        /// <summary>
        /// Checks to see if the UI should show a Clear button or not based on what is or isn't selected.
        /// </summary>
        private void EvaluateDisplay()
        {
            if (_addedButton == null) return;
            _addedButton.Visibility = AssociatedObject.SelectedIndex == -1 ? Visibility.Collapsed : Visibility.Visible;
            // To prevent the text or content from being overlapped by the button, adjust the margins if we have reference to the presenter.
            if (_presenter != null)
            {
                _presenter.Margin = new Thickness(
                    _originalPresenterMargins.Left, 
                    _originalPresenterMargins.Top, 
                    _addedButton.Visibility == Visibility.Visible ? ClearButtonSize + 6 : _originalPresenterMargins.Right, 
                    _originalPresenterMargins.Bottom);
            }
        }
        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            // After we have loaded, we will have access to the Children objects. We don't want this running again.
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
            // The ComboBox primary Grid is named  MainGrid. We need this to inject the button control. If missing, you may be using a custom control.
            if (!(AssociatedObject.FindChild("MainGrid") is Grid grid)) return;
            // Find the content presenter. We need this to adjust the margins if the Clear icon is present.
            _presenter = grid.FindChildren<ContentPresenter>().FirstOrDefault();
            if (_presenter != null) _originalPresenterMargins = _presenter.Margin;
            // Create the new button to put in the view
            _addedButton = new Button
            {
                Height = ClearButtonSize, 
                Width = ClearButtonSize,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            
            // Find the resource for the button - In this case, our NoChromeButton Style has no button edges or chrome
            if (Application.Current.TryFindResource("NoChromeButton") is Style style)
            {
                _addedButton.Style = style;
            }
            // Find the resource you want to put in the button content
            if (Application.Current.TryFindResource("RemoveIcon") is FrameworkElement content)
            {
                _addedButton.Content = content;
            }
            // Hook into the Click Event to handle clearing
            _addedButton.Click += ClearSelectionButtonClick;
            
            // Evaluate if we should display. If there is nothing selected, don't show.
            EvaluateDisplay();
            // Add the button to the grid - First Column as it will be right justified.
            grid.Children.Add(_addedButton);
        }
        private void ClearSelectionButtonClick(object sender, RoutedEventArgs e)
        {
            // Sets the selected index to -1 which will set the selected item to null.
            AssociatedObject.SelectedIndex = -1;
        }
        /// <summary>
        /// The Button Width and Height. This can be changed in the Xaml if a different size visual is desired.
        /// </summary>
        public int ClearButtonSize { get; set; } = 15;
    }
