           try
           {
               System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
               obj = null;
           }
           catch (Exception)
           {
               obj = null;
           }
           finally
           {
               GC.Collect();
           }
       } 
