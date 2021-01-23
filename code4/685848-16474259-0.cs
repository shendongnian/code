    public static class Extensions
    {
        public static IEnumerable<string> GetControlPath(this Control c)
        {
            yield return c.Name;
    
            if (c.Parent != null)
            {
                Control parent = c.Parent;
    
                while (parent != null)
                {
                    yield return parent.Name;
                    parent = parent.Parent;
                }                
            }
        }
    }
