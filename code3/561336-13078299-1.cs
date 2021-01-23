    private bool _isDragging;
        private void listBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
        }
        Adorner _adorner;
        private void listBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                _isDragging = true;
                if (_listBox.SelectedValue != null)
                {
                    DragDrop.DoDragDrop(_listBox, _listBox.SelectedValue,
                       DragDropEffects.Move);
                }
            }
        }
       
    
    private ListBoxItem FindlistBoxItem(DragEventArgs e)
        {
            var visualHitTest = VisualTreeHelper.HitTest(_listBox, e.GetPosition(_listBox)).VisualHit;
    
            ListBoxItem listBoxItem = null;
    
            while (visualHitTest != null)
            {
                if (visualHitTest is ListBoxItem)
                {
                    listBoxItem = visualHitTest as ListBoxItem;
    
                    break;
                }
                else if (visualHitTest == _listBox)
                {
                    Console.WriteLine("Found listBox instance");
                    return null;
                }
    
                visualHitTest = VisualTreeHelper.GetParent(visualHitTest);
            }
    
            return listBoxItem;
        }
    
        void ClearAdorner()
        {
            if (_adorner != null)
            {
                var adornerLayer = AdornerLayer.GetAdornerLayer(_listBox);
                adornerLayer.Remove(_adorner);
            }
        }
    
        private void listBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
    
            ClearAdorner();
    
            var listBoxItem = FindlistBoxItem(e);
    
            if (listBoxItem == null || listBoxItem.DataContext == _listBox.SelectedItem) return;
    
            if (IsInFirstHalf(listBoxItem, e.GetPosition(listBoxItem)))
            {
                var adornerLayer = AdornerLayer.GetAdornerLayer(_listBox);
                _adorner = new DropBeforeAdorner(listBoxItem);
                adornerLayer.Add(_adorner);
            }
            else if (IsInLastHalf(listBoxItem, e.GetPosition(listBoxItem)))
            {
                var adornerLayer = AdornerLayer.GetAdornerLayer(_listBox);
                _adorner = new DropAfterAdorner(listBoxItem);
                adornerLayer.Add(_adorner);
            }
            
        }
    
        private void listBox_Drop(object sender, DragEventArgs e)
        {
            if (_isDragging)
            {
                _isDragging = false;
                ClearAdorner();
    
                var listBoxItem = FindlistBoxItem(e);
    
                if (listBoxItem == null || listBoxItem.DataContext == _listBox.SelectedItem) return;
    
                var drop = _listBox.SelectedItem as Export.Domain.Components.Component;
                var target = listBoxItem.DataContext as Export.Domain.Components.Component;
    
                var listBoxItem = GetlistBoxItemControl(listBoxItem);
    
                if (IsInFirstHalf(listBoxItem, e.GetPosition(listBoxItem)))
                {
                    var vm = this.DataContext as ComponentlistBoxModel;
                    vm.DropBefore(drop, target);
                }                
                else if (IsInLastHalf(listBoxItem, e.GetPosition(listBoxItem)))
                {
                    var vm = this.DataContext as ComponentlistBoxModel;
                    vm.DropAfter(drop, target);
                }
            }
        }
    
        
    
        public static bool IsInFirstHalf(FrameworkElement container, Point mousePosition)
        {
            return mousePosition.Y < (container.ActualHeight/2);
        }
    
        public static bool IsInLastHalf(FrameworkElement container, Point mousePosition)
        {
            return mousePosition.Y > (container.ActualHeight/2);
        }
    
       
