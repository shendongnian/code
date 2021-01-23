    private void ContextMenuSendBackward_Click(object sender, RoutedEventArgs e)
            {
                Canvas parent = (Canvas)LogicalTreeHelper.GetParent(this);
                foreach (var child in parent.Children)
                {
                    Canvas.SetZIndex((UIElement)child, 0);
                }
                Canvas.SetZIndex(selected, 1);
            }
