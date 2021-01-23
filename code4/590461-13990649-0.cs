        Try this code for taking snapshot of your control. Pass the UIElement to this method in which you want. Hope this will solve your issue
        private WriteableBitmap RenderControlAsImage(UIElement element)
        {
            element.UpdateLayout();
            element.Measure(new Size(element.Width, element.Height));
            element.Arrange(new Rect(0, 0, element.Width, element.Height));
            return new WriteableBitmap(element, null);
        }
