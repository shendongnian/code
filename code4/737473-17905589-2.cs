      // Lazy creation of integer array with 6 items (declaration only, no physical allocation)
      private static Lazy<int[]> m_Array = new Lazy<int[]>(() => new int[6]);
    
      public static int[] Arr {
        get {
          return m_Array.Value; // <- int[6] will be created here
        }
      }
