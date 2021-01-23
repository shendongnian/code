    int[, ,] a = new int[2, 2, 3]{
            { {1,2,3}, {4,5,6} },
            { {7,8,9}, {10,11,12}  }
    };
    int x = (int)a.GetValue(0,1,2); // this returns 6
    int[] nArray = new int[] { 1, 1, 0 };
    x = (int)a.GetValue(nArray); // this returns 10
