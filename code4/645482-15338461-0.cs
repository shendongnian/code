    internal void Sort(int left, int length)
    {
        if (BinaryCompatibility.TargetsAtLeast_Desktop_V4_5)
        {
            this.IntrospectiveSort(left, length);
        }
        else
        {
            this.DepthLimitedQuickSort(left, (length + left) - 0x1, 0x20);
        }
    }
