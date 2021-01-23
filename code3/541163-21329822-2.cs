        public static void MoveItemUp<T>(this ObservableCollection<T> baseCollection, int selectedIndex)
        {
            //# Check if move is possible
            if (selectedIndex <= 0)
                return;
            //# Move-Item
            baseCollection.Move(selectedIndex - 1, selectedIndex);
        }
        public static void MoveItemDown<T>(this ObservableCollection<T> baseCollection, int selectedIndex)
        {
            //# Check if move is possible
            if (selectedIndex < 0 || selectedIndex + 1 >= baseCollection.Count)
                return;
            //# Move-Item
            baseCollection.Move(selectedIndex + 1, selectedIndex);
        }
        public static void MoveItemDown<T>(this ObservableCollection<T> baseCollection, T selectedItem)
        {
            //# MoveDown based on Item
            baseCollection.MoveItemDown(baseCollection.IndexOf(selectedItem));
        }
        public static void MoveItemUp<T>(this ObservableCollection<T> baseCollection, T selectedItem)
        {
            //# MoveUp based on Item
            baseCollection.MoveItemUp(baseCollection.IndexOf(selectedItem));
        }
