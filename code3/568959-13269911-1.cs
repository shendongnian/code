     public class ListViewBehavior : Behavior<ListView>
        {
            protected override void OnAttached()
            {
                AssociatedObject.KeyDown += OnKeyDown;
            }
    
            protected override void OnDetaching()
            {
                AssociatedObject.KeyDown -= OnKeyDown;
            }
    
            private void OnKeyDown(object sender, KeyEventArgs e)
            {
                var key = e.Key.ToString();
    
                AssociatedObject.SelectedItems.Clear();
    
                foreach (var item in AssociatedObject.Items)
                {
                    var i = (item as ListViewItem).Content;
                    if(i.ToString().StartsWith(key))
                    {
                        AssociatedObject.SelectedItems.Add(item);
                    }
    
                }
            }
        }
