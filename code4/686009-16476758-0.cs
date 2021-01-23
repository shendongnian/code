    using System;
    #if DEBUG
    using MyType = System.Double;
    #else
    //Float
    using MyType = System.Single;
    #endif
