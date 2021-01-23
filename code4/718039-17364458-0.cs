    class Mine {
      public int A { get; set; }
    }
    Mine A = new Mine() { A = 3; }
    Mine B = A;
    B.A = 5;
    // A.A is now 5.
