    //I'd make a few signatures....
    bool OnTest<T1, T2> (Action<ComObject, T1, T2> logic, T1 first, T2 second)
        {
            bool result = false;
            ComObject com = null;
            //no checks needed re parameters
            //Can add reflection tests here if wanted before code is run.
            try
            {
                com = new ComObject();
                //can't return
                logic(com, first,second);
            }
            finally
            {
                // Release all COM objects.
                System.Runtime.InteropServices.Marshal.ReleaseComObject(com);
    
                // Set all COM objects to [null].
                // The base class will take care of explicit garbage collection.
                com = null;
                //If you want, we can check each argument and if it is disposable dispose.
                if (first is IDisposable  && first != null) ((IDisposable) first).Dispose();
                ...
            }
    
            return (result);  //can't be changed
        }
