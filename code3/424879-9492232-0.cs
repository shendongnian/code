    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern IntPtr SendMessage(IntPtr hWnd, UInt32 uMsg, IntPtr wParam, ref HDITEM lParam);
    
    public void SetSortArrow(int column, SortOrder sortOrder)
    {
        var pHeader = SendMessage(this.Handle, LVM_GETHEADER, UIntPtr.Zero, IntPtr.Zero);
    
        var pColumn = new IntPtr(column);
        var headerItem = new HDITEM {mask = HDI_FORMAT};
    
        SendMessage(pHeader, HDM_GETITEM, pColumn, ref headerItem);
    
        switch (sortOrder)
        {
            case SortOrder.Ascending:
                headerItem.fmt &= ~HDF_SORTDOWN;
                headerItem.fmt |= HDF_SORTUP;
                break;
            case SortOrder.Descending:
                headerItem.fmt &= ~HDF_SORTUP;
                headerItem.fmt |= HDF_SORTDOWN;
                break;
            case SortOrder.None:
                headerItem.fmt &= ~(HDF_SORTDOWN | HDF_SORTUP);
                break;
        }
    
        SendMessage(pHeader, HDM_SETITEM, pColumn, ref headerItem);
    }
