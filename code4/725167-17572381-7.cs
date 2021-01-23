    Result (.ToList()):
    ListCopy_1(...) == System.Collections.Generic.List`1[System.Int32]
    10 iterations done in 474 ms.
    Average time: 47.40000 ms.
    Result (for-cycle with .Add()):
    ListCopy_2(...) == System.Collections.Generic.List`1[System.Int32]
    
    10 iterations done in 1896 ms.
    Average time: 189.60000 ms.
    Result (ctor with .ToArray()):
    ListCopy_3(...) == System.Collections.Generic.List`1[System.Int32]
    
    10 iterations done in 981 ms.
    Average time: 98.10000 ms.
    Result (.AddRange()):
    ListCopy_4(...) == System.Collections.Generic.List`1[System.Int32]
    
    10 iterations done in 959 ms.
    Average time: 95.90000 ms.
    Result (new List<int>(list)):
    ListCopy_5(...) == System.Collections.Generic.List`1[System.Int32]
    
    10 iterations done in 480 ms.
    Average time: 48.00000 ms.
