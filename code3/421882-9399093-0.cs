        void ClearCollection()
        {
            while(collection.Count > 0)
            {
                // Could handle the event here...
                // collection[0].PropertyChanged -= CollectionItemChanged;
                collection.RemoveAt(collection.Count -1);
            }
        }
