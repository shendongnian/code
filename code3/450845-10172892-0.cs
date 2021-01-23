    public static class ContentControlEx
    {
        public static void DisableTextBoxes(this ContentControl contentControl)
        {
            FrameworkElement p = contentControl as FrameworkElement;
            var ts = p.GetChildren<TextBox>();
            ts.ForEach(a => { if (!a.IsReadOnly) a.IsReadOnly = true; });
        }
        public static List<T> GetChildren<T>(this UIElement parent) where T : UIElement
        {
            List<T> list = new List<T>();
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++) {
                UIElement child = VisualTreeHelper.GetChild(parent, i) as UIElement;
                if (child != null) {
                    if (child is T)
                        list.Add(child as T);
                    List<T> l1 = GetChildren<T>(child);
                    foreach (T u in l1)
                        list.Add(u);
                }
            }
            return list;
        }
    }
