    [Flags] enum UnaryOperatorKind { 
      Integer = 0x0001, 
      ... 
      UnaryMinus = 0x0100,
      ... 
      IntegerMinus = Integer | UnaryMinus
      ... }
    [Flags] enum BinaryOperatorKind { 
      ...
      IntegerAddition = UnaryOperatorKind.Integer | Addition
      ... }
