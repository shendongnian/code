        public class FrameworkElementScrollviewerScrollingBehavior : Behavior<FrameworkElement>
    {
        private FrameworkElement _AssociatedElement;
        private ScrollViewer _listboxScrollViewer = null;
        #region OnAttached
        protected override void OnAttached()
        {
            base.OnAttached();
            _AssociatedElement = AssociatedObject;
            _AssociatedElement.Loaded += OnControlLoaded;
            _AssociatedElement.Unloaded += new RoutedEventHandler(_AssociatedElement_Unloaded);
            //TODO: register/subscrive for event/message from the VM that tells you the scrollviewer to do something
        }
        //TODO: handle the event using the _AssociatedElement as the control you are acting on
        void _AssociatedElement_Unloaded(object sender, RoutedEventArgs e)
        {
            Cleanup();
        }
        #endregion
        #region OnDetaching
        protected override void OnDetaching()
        {
            Cleanup();
            base.OnDetaching();
        }
        #endregion
        private bool _isCleanedUp;
        private void Cleanup()
        {
            if (!_isCleanedUp)
            {
                _AssociatedElement.Loaded -= OnControlLoaded;
                _AssociatedElement.Unloaded -= _AssociatedElement_Unloaded;
            }
        }
        #region OnControlLoaded
        private void OnControlLoaded(object sender, RoutedEventArgs args)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element != null)
            {
                _listboxScrollViewer = GetDescendantByType(sender as Visual, typeof(ScrollViewer)) as ScrollViewer;
                if (_listboxScrollViewer.ComputedVerticalScrollBarVisibility == Visibility.Visible)
                    //do something when content is scrollable
            }
        }
        #endregion
        #region GetDescendantByType
        /// <summary>
        /// Gets the descendent of type
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static Visual GetDescendantByType(Visual element, Type type)
        {
            if (element == null) return null;
            if (element.GetType() == type) return element;
            Visual foundElement = null;
            if (element is FrameworkElement)
                (element as FrameworkElement).ApplyTemplate();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
                foundElement = GetDescendantByType(visual, type);
                if (foundElement != null)
                    break;
            }
            return foundElement;
        }
        #endregion
    }
