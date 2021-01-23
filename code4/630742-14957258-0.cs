    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Security;
    [assembly: AllowPartiallyTrustedCallers]
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                PreJIT();
            }
            [SecuritySafeCritical]
            static void PreJIT()
            {
                RuntimeHelpers.PrepareMethod(
                    System.Reflection.Emit.DynamicMethod.GetCurrentMethod()
                    .MethodHandle);
            }
        }
    }
