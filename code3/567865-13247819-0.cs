    public class ChildSpaceBehavior : Behavior<StackPanel>
        {
            public static readonly DependencyProperty ShowDetailsCommandProperty = DependencyProperty.Register("ShowDetailsCommand", typeof(RelayCommand), typeof(ChildSpaceBehavior), new PropertyMetadata());
    
            public RelayCommand ShowDetailsCommand
            {
                get { return (RelayCommand)GetValue(ShowDetailsCommandProperty); }
                set { SetValue(ShowDetailsCommandProperty, value); }
            }
    
            private bool _isMoreChildrenItemVisible;
    
            protected override void OnAttached()
            {
                AssociatedObject.LayoutUpdated += OnLayoutUpdated;
            }
    
            protected override void OnDetaching()
            {
                AssociatedObject.LayoutUpdated -= OnLayoutUpdated;
            }
    
            private void OnLayoutUpdated(object sender, EventArgs e)
            {
                var height = AssociatedObject.Height;
                var children = AssociatedObject.Children;
                double childHeighSum = 0;
    
                var childList = new List<FrameworkElement>();
    
                foreach (FrameworkElement child in children)
                {
                    if (childHeighSum > height)
                    {
                        ShowMoreChildrenItem(childList);
                        break;
                    }
    
                    if (childHeighSum + child.ActualHeight > height)
                    {
                        ShowMoreChildrenItem(childList);
                        break;
                    }
    
                    childHeighSum += child.ActualHeight;
                    childList.Add(child);
                }
            }
    
            private void ShowMoreChildrenItem(List<FrameworkElement> childList)
            {
                if (_isMoreChildrenItemVisible) return;
    
                var moreItem = new Button{ Content = "..." };
                moreItem.Command = ShowDetailsCommand;
    
                var itemsToRemove = new List<FrameworkElement>();
    
                foreach (FrameworkElement child in AssociatedObject.Children)
                {
                    if(childList.Contains(child) == false) itemsToRemove.Add(child);
                }
    
                foreach (var element in itemsToRemove)
                {
                    AssociatedObject.Children.Remove(element);
                }
    
                AssociatedObject.Children.Add(moreItem);
    
                _isMoreChildrenItemVisible = true;
            }
        }
