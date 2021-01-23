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
