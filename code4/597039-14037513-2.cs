    public static class ExtensionMethod
    {
        public static IEnumerable<Control> FindAll(this ControlCollection collection)
        {
            foreach (Control item in collection)
            {
                yield return item;
    
                if (item.HasControls())
                {
                    foreach (var subItem in item.Controls.FindAll())
                    {
                        yield return subItem;
                    }
                }
            }
        }
    
        public static IEnumerable<T> FindAll<T>(this ControlCollection collection) where T : Control
        {
            return collection.FindAll().OfType<T>();
        }
    }
