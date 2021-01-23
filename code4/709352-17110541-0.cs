        class IntRange {
          public IntRange(int val, bool isMax)
            : this(isMax ? 0 : val, isMax ? val : int.MaxValue) {
          }
          public IntRange(int min, int max) {
          }
        }
