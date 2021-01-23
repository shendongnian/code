            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is Visual)
                {
                    Point point = ((Visual)child).PointFromScreen(screenPoint);
                    Rect rect = VisualTreeHelper.GetDescendantBounds((Visual)child);
                    
                    if (!rect.Contains(point))
                        continue;
                }
                if (child is TDescendantType)
                {
                    return (TDescendantType)child;
                }
                child = FindDescendant<TDescendantType>(child, screenPoint);
                if (child != null)
                {
                    return (TDescendantType)child;
                }
            }
            return null;
        }
