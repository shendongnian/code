      int[] A = ...
    
      for(int i = A.GetLowerBound(0); i <= A.GetUpperBound(0); ++i) {
        int item = A[i];
        ...
      }
      // ... or multidimension
    
      int[,,] A = ...;
    
      for (int i = A.GetLowerBound(0); i <= A.GetUpperBound(0); ++i)
        for (int j = A.GetLowerBound(1); j <= A.GetUpperBound(1); ++j)
          for (int k = A.GetLowerBound(2); k <= A.GetUpperBound(2); ++k) {
            int item = A[i, j, k];
            ...
          }
