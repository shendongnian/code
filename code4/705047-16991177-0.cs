    class ObservableDictionary<TKey,TValue>
    {
         // This class already knows about TKey and TValue since it's an inner class in the "outer" generic class
         protected class KeyedDictionaryEntryCollection : KeyedCollection<TKey, DictionaryEntry> 
         {
            // Your existing code, as is...
         }
    }
