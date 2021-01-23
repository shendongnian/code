**4** The problem seems to come from the private List<Dictionary<string, string>> _list that is note disposed correctly. So we'll try to find the instances of the type. Type !DumpHeap -stat -type List in the Immediate Window. Result:
    total 0 objects
    Statistics:
          MT    Count    TotalSize Class Name
    0570ffdc        1           24 System.Collections.Generic.List1[[System.Threading.CancellationTokenRegistration, mscorlib]]
    04f63e50        1           24 System.Collections.Generic.List1[[System.Security.Policy.StrongName, mscorlib]]
    00202800        2           48 System.Collections.Generic.List1[[System.Collections.Generic.Dictionary2[[System.String, mscorlib],[System.String, mscorlib]], mscorlib]]
    Total 4 objects
The problematic type is the last one `List<Dictionary<...>>`. There are 2 instances and the MethodTable (a kind of reference of the type) is 00202800.
**5** To get the references, type !DumpHeap -mt 00202800. Result:
     Address       MT     Size
    02618a9c 00202800       24     
    0733880c 00202800       24     
    total 0 objects
    Statistics:
          MT    Count    TotalSize Class Name
    00202800        2           48 System.Collections.Generic.List1[[System.Collections.Generic.Dictionary2[[System.String, mscorlib],[System.String, mscorlib]], mscorlib]]
    Total 2 objects
The two instances are shown, with their addresses: 02618a9c and 0733880c
**6** To find how they are references: Type !GCRoot 02618a9c (for the first instance) or !GCRoot 0733880c (for the second). Result (I have not copied all the result but kept an important part):
    ESP:3bef9c:Root:  0261874c(ConsoleApplication1.Test1)->
      0261875c(System.Collections.Concurrent.BlockingCollection1[[ConsoleApplication1.Data, ConsoleApplication1]])->
      02618784(System.Collections.Concurrent.ConcurrentQueue1[[ConsoleApplication1.Data, ConsoleApplication1]])->
      02618798(System.Collections.Concurrent.ConcurrentQueue1+Segment[[ConsoleApplication1.Data, ConsoleApplication1]])->
      026187bc(ConsoleApplication1.Data[])->
      02618a9c(System.Collections.Generic.List1[[System.Collections.Generic.Dictionary2[[System.String, mscorlib],[System.String, mscorlib]], mscorlib]])
