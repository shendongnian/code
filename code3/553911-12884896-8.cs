            List<MyClass> UndoCache = new List<MyClass>();
        MyClass myRealObject;
        int unDoCount = 10;
           void Undo()
        {
            myRealObject = UndoCache.Last();
            //remove this object from cache.
            UndoCache.RemoveAt(UndoCache.Count - 1);
        }
