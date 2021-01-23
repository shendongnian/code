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
            if (selectedIndex + 1 >= baseCollection.Count)
                return;
            //# Move-Item
            baseCollection.Move(selectedIndex + 1, selectedIndex);
        }
