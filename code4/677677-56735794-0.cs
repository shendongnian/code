    private void UIElement_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scroll = (ScrollViewer)sender;
            if (e.Delta < 0)
            {
                if (scroll.VerticalOffset - e.Delta <= scroll.ExtentHeight - scroll.ViewportHeight)
                {
                    scroll.ScrollToVerticalOffset(scroll.VerticalOffset - e.Delta);
                }
                else
                {
                    scroll.ScrollToBottom();
                }
            }
            else
            {
                if (scroll.VerticalOffset + e.Delta > 0)
                {
                    scroll.ScrollToVerticalOffset(scroll.VerticalOffset - e.Delta);
                }
                else
                {
                    scroll.ScrollToTop();
                }
            }
            e.Handled = true;
        }
