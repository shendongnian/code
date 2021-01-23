      private static void PassTheObj()
      {
         MethodThatAcceptsObj(realObject.Copy());  
      }
      private static void ValidateObj(customObject objCopy)
      {
         if (objCopy.IsValid()) realObject = objCopy;
      }
