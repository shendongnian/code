    public bool IsIdentityMatrix()
    {
        if (IsSquareMatrix())
            return checkSquareMatrixForIdentity();
        else
            return false;
    }
    private bool checkSquareMatrixForIdentity()
    {
        for (int i = 0; i < this.RowCount; i++)
        {
            for (int j = 0; j < this.ColumnCount; j++)
            {
                decimal checkValue = 0;
                if (i == j)
                {
                    checkValue = 1;
                }
                if (mInnerMatrix[i, j] != checkValue)
                {
                    return false;
                }
            }
        }
        return true;
    }
