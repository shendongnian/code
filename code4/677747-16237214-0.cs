    public static class StaticClassToHandleExtensions
    {
        public static Control FindSiblingControl(this Control control, string id)
        {
            Control parent = control.Parent;
            while (parent.GetType() != typeof(ContentPlaceHolder) && parent.GetType() != typeof(Page))
                parent = parent.Parent;
            return parent.FindControl(id);
        }
    }
