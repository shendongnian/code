    public static class MouseDoubleClickBehavior
    {
        /// <summary>
        /// Hooks up a weak event against the source Selectors MouseDoubleClick
        /// if the Selector has asked for the HandleDoubleClick to be handled
        ///�
        /// If the source Selector has expressed an interest in not having its
        /// MouseDoubleClick handled the internal reference
        /// </summary>
        private static void OnHandleDoubleClickCommandChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement ele = d as FrameworkElement;
            if (ele != null)
            {
                ele.MouseLeftButtonDown -= OnMouseDoubleClick;
                if (e.NewValue != null)
                {
                    ele.MouseLeftButtonDown += OnMouseDoubleClick;
                }
            }
        }
        /// <summary>
        /// TheCommandToRun : The actual ICommand to run
        /// </summary>
        public static readonly DependencyProperty DoubleClickCommandProperty =
            DependencyProperty.RegisterAttached("DoubleClickCommand",
                typeof(ICommand),
                typeof(MouseDoubleClickBehavior),
                new FrameworkPropertyMetadata((ICommand)null,
                    new PropertyChangedCallback(OnHandleDoubleClickCommandChanged)));
        /// <summary>
        /// Gets the TheCommandToRun property. �
        /// </summary>
        public static ICommand GetDoubleClickCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(DoubleClickCommandProperty);
        }
        /// <summary>
        /// Sets the TheCommandToRun property. �
        /// </summary>
        public static void SetDoubleClickCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(DoubleClickCommandProperty, value);
        }
        #region Handle the event
        /// <summary>
        /// Invoke the command we tagged.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //check for double clicks.
            if (e.ClickCount != 2)
                return;
            FrameworkElement ele = sender as FrameworkElement;
            DependencyObject originalSender = e.OriginalSource as DependencyObject;
            if (ele == null || originalSender == null)
                return;
            ICommand command = (ICommand)(sender as DependencyObject).GetValue(DoubleClickCommandProperty);
            if (command != null)
            {
                if (command.CanExecute(null))
                    command.Execute(null);
            }
        }
        #endregion
    }
