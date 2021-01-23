        public static IEnumerable<DependencyObject> getChilds(this DependencyObject parent)
        {
            if (parent == null) yield break;
            //use the logical tree for content / framework elements
            foreach (object obj in LogicalTreeHelper.GetChildren(parent))
            {
                var depObj = obj as DependencyObject;
                if (depObj != null)
                    yield return depObj;
            }
            //use the visual tree for Visual / Visual3D elements
            if (parent is Visual || parent is Visual3D)
            {
                int count = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < count; i++)
                {
                    yield return VisualTreeHelper.GetChild(parent, i);
                }
            }
        }
