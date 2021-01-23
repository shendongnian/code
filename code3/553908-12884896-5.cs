          void Undo()
        {
            if (UndoCache.Count > 0)
            {
                if (usedCachIdx > 0)
                {
                    usedCachIdx--;
                    myRealObject = UndoCache[usedCachIdx];
                }
            }
        }
  
 
   
