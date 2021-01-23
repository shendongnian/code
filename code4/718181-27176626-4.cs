        //Release all registered interop objects in reverse order
        public void unregister()
        {
            //Loop object list in reverse order and release Office object
            for (int i=_interopObjectList.Count-1; i>=0 ; i -= 1)
            { ReleaseComObject(_interopObjectList[i]); }
            //Clear object list
            _interopObjectList.Clear();
        }
        /// <summary>
        /// Release a com interop object 
        /// </summary>
        /// <param name="obj"></param>
         public static void ReleaseComObject(object obj)
         {
             if (obj != null && InteropServices.Marshal.IsComObject(obj))
                 try
                 {
                     InteropServices.Marshal.FinalReleaseComObject(obj);
                 }
                 catch { }
                 finally
                 {
                     obj = null;
                 }
             GC.Collect();
             GC.WaitForPendingFinalizers();
             GC.Collect();
             GC.WaitForPendingFinalizers();
         }
