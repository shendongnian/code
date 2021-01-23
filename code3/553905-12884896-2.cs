      List<MyClass> UndoCache = new List<MyClass>();
        int usedCachIdx;
        MyClass myRealObject;
        int unDoCount = 10;
          void Undo()
        {
            if (UndoCache.Count>0)
            {
                if (usedCachIdx>0)
                {
                    myRealObject = UndoCache[-1];
                }
            }
        }
