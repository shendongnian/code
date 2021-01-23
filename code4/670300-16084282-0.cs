            uint pdwCntPublicACs = 0;
            IntPtr ppACs = new IntPtr();
            // Pin down variables
            GCHandle handle_pdwCntPublicACs = GCHandle.Alloc(pdwCntPublicACs, GCHandleType.Pinned);
            GCHandle handle_ppACs = GCHandle.Alloc(ppACs, GCHandleType.Pinned);
            uint retval = NetworkIsolationEnumAppContainers((Int32) NETISO_FLAG.NETISO_FLAG_MAX, out pdwCntPublicACs, out ppACs);
            //release pinned variables.
            handle_pdwCntPublicACs.Free();
            handle_ppACs.Free();
