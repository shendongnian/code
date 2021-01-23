     public class DragDropRowBehavior : Behavior<DataGrid>
    {
        private object draggedItem;
        private bool isEditing;
        private bool isDragging;
        #region DragEnded
        public static readonly RoutedEvent DragEndedEvent =
            EventManager.RegisterRoutedEvent("DragEnded", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DragDropRowBehavior));
        public static void AddDragEndedHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
                uie.AddHandler(DragDropRowBehavior.DragEndedEvent, handler);
        }
        public static void RemoveDragEndedHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
                uie.RemoveHandler(DragDropRowBehavior.DragEndedEvent, handler);
        }
        private void RaiseDragEndedEvent()
        {
            var args = new RoutedEventArgs(DragDropRowBehavior.DragEndedEvent);
            AssociatedObject.RaiseEvent(args);
        }
        #endregion
        #region Popup
        public static readonly DependencyProperty PopupProperty =
            DependencyProperty.Register("Popup", typeof(System.Windows.Controls.Primitives.Popup), typeof(DragDropRowBehavior));
        public System.Windows.Controls.Primitives.Popup Popup
        {
            get { return (System.Windows.Controls.Primitives.Popup)GetValue(PopupProperty); }
            set { SetValue(PopupProperty, value); }
        }
        #endregion
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.BeginningEdit += OnBeginEdit;
            AssociatedObject.CellEditEnding += OnEndEdit;
            AssociatedObject.MouseLeftButtonUp += OnMouseLeftButtonUp;
            AssociatedObject.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
            AssociatedObject.MouseMove += OnMouseMove;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.BeginningEdit -= OnBeginEdit;
            AssociatedObject.CellEditEnding -= OnEndEdit;
            AssociatedObject.MouseLeftButtonUp -= OnMouseLeftButtonUp;
            AssociatedObject.MouseLeftButtonDown -= OnMouseLeftButtonDown;
            AssociatedObject.MouseMove -= OnMouseMove;
            Popup = null;
            draggedItem = null;
            isEditing = false;
            isDragging = false;
        }
        private void OnBeginEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            isEditing = true;
            //in case we are in the middle of a drag/drop operation, cancel it...
            if (isDragging) ResetDragDrop();
        }
        private void OnEndEdit(object sender, DataGridCellEditEndingEventArgs e)
        {
            isEditing = false;
        }
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isEditing) return;
            var row = UIHelpers.TryFindFromPoint<DataGridRow>((UIElement)sender, e.GetPosition(AssociatedObject));
            if (row == null || row.IsEditing) return;
            //set flag that indicates we're capturing mouse movements
            isDragging = true;
            draggedItem = row.Item;
        }
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!isDragging || isEditing)
                return;
            //get the target item
            var targetItem = AssociatedObject.SelectedItem;
            if (targetItem == null || !ReferenceEquals(draggedItem, targetItem))
            {
                //get target index
                var targetIndex = ((AssociatedObject).ItemsSource as IList).IndexOf(targetItem);
                //remove the source from the list
                ((AssociatedObject).ItemsSource as IList).Remove(draggedItem);
                //move source at the target's location
                ((AssociatedObject).ItemsSource as IList).Insert(targetIndex, draggedItem);
                //select the dropped item
                AssociatedObject.SelectedItem = draggedItem;
                RaiseDragEndedEvent();
            }
            //reset
            ResetDragDrop();
        }
        private void ResetDragDrop()
        {
            isDragging = false;
            Popup.IsOpen = false;
            AssociatedObject.IsReadOnly = false;
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging || e.LeftButton != MouseButtonState.Pressed)
                return;
            Popup.DataContext = draggedItem;
            //display the popup if it hasn't been opened yet
            if (!Popup.IsOpen)
            {
                //switch to read-only mode
                AssociatedObject.IsReadOnly = true;
                //make sure the popup is visible
                Popup.IsOpen = true;
            }
            var popupSize = new Size(Popup.ActualWidth, Popup.ActualHeight);
            Popup.PlacementRectangle = new Rect(e.GetPosition(AssociatedObject), popupSize);
            //make sure the row under the grid is being selected
            var position = e.GetPosition(AssociatedObject);
            var row = UIHelpers.TryFindFromPoint<DataGridRow>(AssociatedObject, position);
            if (row != null) AssociatedObject.SelectedItem = row.Item;
        }
    }
