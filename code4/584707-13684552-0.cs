        try
            {
                // COM Code here
            }
            catch (System.OutOfMemoryException ex)
            {
                throw new System.Runtime.InteropServices.COMException("E_OUTOFMEMORY", ex);
            }
