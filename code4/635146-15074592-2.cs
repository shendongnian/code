    public static class ObservableCollectionExtensionMethods
        {
            public static void Replace<T>(this ObservableCollection<T> old, ObservableCollection<T> @new)
            {
                old.Clear();
                foreach (var item in @new)
                {
                    old.Add(item);
                }
            }
        }
