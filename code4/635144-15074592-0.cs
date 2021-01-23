    public static class ObservableCollectionEntensionMethods
        {
            public static void Relace<T>(this ObservableCollection<T> old, ObservableCollection<T> @new)
            {
                old.Clear();
                foreach (var item in @new)
                {
                    old.Add(item);
                }
            }
        }
