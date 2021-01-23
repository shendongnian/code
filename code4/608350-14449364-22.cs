As I've mentioned, using DumpHeap is not well suited for the current task implying value types. Why? Because value types are not in the heap but on the stack. Seeing this is very simple: try !DumpHeap -stat -type ConsoleApplication1.Data on the breakpoint. Result:
    total 0 objects
    Statistics:
          MT    Count    TotalSize Class Name
    00214c00        1           20 System.Collections.Concurrent.ConcurrentQueue`1[[ConsoleApplication1.Data, ConsoleApplication1]]
    00214e24        1           36 System.Collections.Concurrent.ConcurrentQueue`1+Segment[[ConsoleApplication1.Data, ConsoleApplication1]]
    00214920        1           40 System.Collections.Concurrent.BlockingCollection`1[[ConsoleApplication1.Data, ConsoleApplication1]]
    00214f30        1          140 ConsoleApplication1.Data[]
    Total 4 objects
There is an array of Data but no Data. Because DumpHeap only analyses the heap. Then !DumpArray -details 026187bc, the pointer is still here with the same value. And if you compare the roots of the two instances we have found before (with !GCRoot) before executing the line and after, there will be only line removed. Indeed, the refence to the list has only be removed from 1 copy of the value type Data.
