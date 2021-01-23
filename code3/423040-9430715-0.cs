    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security;
    
    namespace NaturalSort
    {
         public sealed class NaturalStringComparer : IComparer<string>
         {
             private readonly int modifier = 1;
    
             public NaturalStringComparer(bool descending)
             {
                 if (descending)
                     modifier = -1;
             }
    
             public NaturalStringComparer()
                 :this(false) {}
    
             public int Compare(string a, string b)
             {
                 return SafeNativeMethods.StrCmpLogicalW(a ?? "", b ?? "") * modifier;
             }
         }
    
         public sealed class NaturalFileInfoComparer : IComparer<FileInfo>
         {
             public int Compare(FileInfo a, FileInfo b)
             {
                 return SafeNativeMethods.StrCmpLogicalW(a.Name ?? "", b.Name ?? "");
             }
         }
    
         [SuppressUnmanagedCodeSecurity]
         internal static class SafeNativeMethods
         {
             [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
             public static extern int StrCmpLogicalW(string psz1, string psz2);
         }
    }
