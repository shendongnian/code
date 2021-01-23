    class B : A { 
      public override void Test(int i) {
        TestCore(i);
      }
      public void Test(double d) {
        TestCore(1);
      }
      private void TestCore(int i) {
        // Combined logic here
      }
    }
