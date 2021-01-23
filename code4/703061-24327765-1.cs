        private void ToggleSelectParticipant(object selectedObjects)
        {
            var items = (System.Collections.IList)selectedObjects;
            var collection = items.Cast<MyItemType>().ToList();
            bool selection = !collection.All(x => x.IsSelected);
            foreach (var item in collection)
                item.IsSelected = selection;
        }
