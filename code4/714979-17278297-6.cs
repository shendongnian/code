        public static IEnumerable<TControl> FindDescendants<TControl>(this Control parent) 
            where TControl : Control
        {
            if (parent == null) throw new ArgumentNullException("control");
            if (parent.HasControls())
            {
                foreach (Control childControl in parent.Controls)
                {
                    var candidate = childControl as TControl;
                    if (candidate != null) yield return candidate;
                    foreach (var nextLevel in FindDescendants<TControl>(childControl))
                    {
                        yield return nextLevel;
                    }
                }
            }
        }
