    using System;
    #if DEBUG
    using MyType = System.Decimal;
    #else
    //Float
    using MyType = System.Single;
    #endif
