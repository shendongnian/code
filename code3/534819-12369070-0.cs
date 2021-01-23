    using System.Runtime.InteropServices;
    using Access = Microsoft.Office.Interop.Access;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var access = new Access.Application();
                access.OpenCurrentDatabase(@"C:\whatever.mdb");
                access.DoCmd.RunSQL("INSERT INTO Table1 SELECT * FROM Table2");
                access.CloseCurrentDatabase();
    
                Marshal.ReleaseComObject(access);
            }
        }
    }
