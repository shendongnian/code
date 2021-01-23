        Descendents(MainFrame).OfType<Button>().FirstOrDefault().Focus(FocusState.Pointer);
        
        public static IEnumerable<DependencyObject> Descendents(DependencyObject root)
        {
            int count = VisualTreeHelper.GetChildrenCount(root);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(root, i);
                yield return child;
                foreach (DependencyObject descendent in Descendents(child))
                    yield return descendent;
            }
        }
