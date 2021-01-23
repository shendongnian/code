    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace PInvokeStructsCS
    {
        class Program
        {
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public struct PtxRow
            {
                public int ptxNumber;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
                public char[] primitive;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
                public int[] primitiveParams;
            }
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public struct csForm
            {
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
                public char[] formId;
                public int endDate;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
                public PtxRow[] ptxRow;
            }
            [DllImport("PInvokeStructsC.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern void fillForm([In, Out]csForm[] data, int count);
            static void Main(string[] args)
            {
                csForm[] forms = new csForm[2];
                
                try
                {
                    fillForm(forms, 2);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.Message);
                    return;
                }
            }
        }
    }
