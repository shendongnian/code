      class TestABC : C
      {
        MyType C.MyMethod()
        {
          // 1
          return null;
        }
        MyType A.MyMethod()
        {
          // 2
          return null;
        }
        MyType B.MyMethod()
        {
          // 3
          return null;
        }
      }
