	    if (view != null)
            {
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(view);
                view = null;
            }
            if (database != null)
            {
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(database);
                database = null;
            }
            GC.Collect();
