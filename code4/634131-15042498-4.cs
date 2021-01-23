    public EmxArrayRealTWrapper(double[,] data)
    {
        int nRow = data.GetLength(0);
        int nCol = data.GetLength(1);
        _dataHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
        _value.data = _dataHandle.AddrOfPinnedObject();
        _sizeHandle = GCHandle.Alloc(new int[] { nRow, nCol }, GCHandleType.Pinned);
        _value.size = _sizeHandle.AddrOfPinnedObject();
        _value.allocatedSize = nCol * nRow;
        _value.numDimensions = 2;
        _value.canFreeData = false;
    }
