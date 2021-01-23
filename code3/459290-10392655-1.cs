    enum First { A, B }
    enum Second { A, B }
    First firstVar;
    Second secondVar;
    // note we're using the `First` name
    First.TryParse("A", out firstVar);  // valid, firstVar <= First.A
    First.TryParse("B", out secondVar); // still valid, secondVar <= Second.B
    // is equivalent to
    Enum.TryParse<First>("A", out firstVar); // generic type is inferred from type of firstVar
    Enum.TryParse<Second>("B", out secondVar); // generic type is inferred from type of secondVar
