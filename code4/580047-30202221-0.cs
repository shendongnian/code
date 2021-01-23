       /// <summary>
       /// Derived (but still abstract) version of KeyedCollection{} to provide a couple of extra 
       /// services, in particular AddOrReplace() and Replace() methods.
       /// </summary>
       public abstract class KeyedList<TKey, TItem> : KeyedCollection<TKey, TItem>
       {
          /// <summary>
          /// Property to provide access to the "hidden" List{} in the base class.
          /// </summary>
          public List<TItem> BaseList
          {
             get { return base.Items as List<TItem>; }
          }
    
    
          /// <summary>
          /// Method to add a new object to the collection, or to replace an existing one if there is 
          /// already an object with the same key in the collection.
          /// </summary>
          public void AddOrReplace(TItem newObject)
          {
             int i = GetItemIndex(newObject);
             if (i != -1)
                base.SetItem(i, newObject);
             else
                base.Add(newObject);
          }
    
    
          /// <summary>
          /// Method to replace an existing object in the collection, i.e., an object with the same key. 
          /// An exception is thrown if there is no existing object with the same key.
          /// </summary>
          public void Replace(TItem newObject)
          {
             int i = GetItemIndex(newObject);
             if (i != -1)
                base.SetItem(i, newObject);
             else
                throw new Exception("Object to be replaced not found in collection.");
          }
    
    
          /// <summary>
          /// Method to get the index into the List{} in the base collection for an item that may or may 
          /// not be in the collection. Returns -1 if not found.
          /// </summary>
          private int GetItemIndex(TItem itemToFind)
          {
             TKey keyToFind = GetKeyForItem(itemToFind);
             return BaseList.FindIndex((TItem existingItem) => 
                                       GetKeyForItem(existingItem).Equals(keyToFind));
          }
       }
