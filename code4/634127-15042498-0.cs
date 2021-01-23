    public EmxArrayRealTWrapper(double[,] data)
    {
        int nRow = data.GetLength(0);
        int nCol = data.GetLength(1);
        double[] flattenedData = new double[nCol * nRow];
        int index = 0;
        for (int col=0; col<nCol; col++)
        {
            for (int row=0; row<nRow, row++)
            {
                flattenedData[index] = data[row, col];
                index++;
            }
        }                    
        _dataHandle = GCHandle.Alloc(flattenedData, GCHandleType.Pinned);
        _value.data = _dataHandle.AddrOfPinnedObject();
        _sizeHandle = GCHandle.Alloc(new int[] { nCol, nRow }, GCHandleType.Pinned);
        _value.size = _sizeHandle.AddrOfPinnedObject();
        _value.allocatedSize = nCol * nRow;
        _value.numDimensions = 2;
        _value.canFreeData = false;
    }
