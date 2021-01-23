        void ObjectChanged()
        {
            if (UndoCache.Count>unDoCount)
            {
                UndoCache.RemoveAt(0);
            }
            UndoCache.Add(DeepCopy<MyClass>(myRealObject));
            //Set the index to the last one
            usedCachIdx = UndoCache.Count;
        }
     public class MyClass { }
