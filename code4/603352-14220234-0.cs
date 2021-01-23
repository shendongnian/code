        if (row1.ReadOnly == row2.ReadOnly)  // change && to ==
        {
            return 0;
        }
        else if (row1.ReadOnly && !row2.ReadOnly)
        {
            return 1;
        }
        else
        {
            return -1;
        }
