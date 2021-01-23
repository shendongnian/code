            void ObjectChanged()
        {
            //remove the first item if we reach limit
            if (UndoCache.Count > unDoCount)
            {
                UndoCache.RemoveAt(0);
            }
            UndoCache.Add(DeepCopy<MyClass>(myRealObject));
        }
        public class MyClass { }
    
