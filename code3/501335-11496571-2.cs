    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    /*
    http://msdn.microsoft.com/en-us/library/aa288468%28v=vs.71%29.aspx
    http://ondotnet.com/pub/a/dotnet/2002/03/18/customcontrols.html?page=2
    http://www.codeproject.com/Articles/2995/The-Complete-Guide-to-C-Strings-Part-I-Win32-Chara
    http://msdn.microsoft.com/en-us/library/z6cfh6e6.aspx
     */
    namespace listViewFromC
    {
    public partial class Form1 : Form
    {
        const int maxRows = 100;
        /*
        [DllImport("cppClassLib.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "?getInt@Class1@cppClassLib@@QAEHXZ")]
            public static extern int getInt();
        */
        // get EntryPoint using
        // "DLL Export Viewer" software
        [DllImport("cppClassLib.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "?getHi2@Class1@cppClassLib@@SAPADXZ")]
            public static extern String getHi2();
        [DllImport("cppClassLib.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "?getHi@Class1@cppClassLib@@SAPADXZ")]
        [return: MarshalAs(UnmanagedType.LPStr)]  
        public static extern string getHi();
        [DllImport("cppClassLib.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "?getHeaderList@Class1@cppClassLib@@SAPAPADXZ")]
        [return: MarshalAs(UnmanagedType.LPArray, 
            ArraySubType=UnmanagedType.LPStr, SizeConst=2)]
        public static extern String[] getHeaderList();
        [DllImport("cppClassLib.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "?getHeaderListTwo@Class1@cppClassLib@@SAHHPAPAPAD@Z")]
        public static extern int getHeaderListTwo(int maxsize,
            [MarshalAs(UnmanagedType.LPArray,
            ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 0)]
            ref String[] result
            );
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct columnType
        {
            public int numberOfRows;
            // note: can't marshal rows field as LPArray must be ByValArray or SafeArray
            // for maximum of maxRows rows
            [MarshalAs(UnmanagedType.ByValArray,
            ArraySubType = UnmanagedType.LPStr,
            SizeConst=maxRows)]
            public String[] rows;
            [MarshalAs(UnmanagedType.LPStr)]
            public String columnName;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct columnType2
        {
            public int numberOfRows;
        }
        
        [DllImport("cppClassLib.dll",
        CallingConvention = CallingConvention.ThisCall,
        EntryPoint = "?getMatrix@Class1@cppClassLib@@SEHHHQAPAUcolumnT@12@@Z")]
        public static extern int getMatrix(int maxColumns,
            int maxRows,
            [MarshalAs(UnmanagedType.LPArray,
            ArraySubType = UnmanagedType.Struct, SizeParamIndex = 0)]
            ref columnType[] matrix);
        [DllImport("cppClassLib.dll",
        CallingConvention = CallingConvention.ThisCall,
        EntryPoint = "?getMatrixNumberOfRowsInColumnZero@Class1@cppClassLib@@SEHHQAUcolumnT@12@@Z")]
        public static extern int getMatrixNumberOfRowsInColumnZero(int maxColumns,
            [MarshalAs(UnmanagedType.LPArray,
            ArraySubType = UnmanagedType.Struct, 
            SizeParamIndex = 0)]
            columnType[] matrix);
        [DllImport("cppClassLib.dll",
        CallingConvention = CallingConvention.ThisCall,
        EntryPoint = "?getMatrixNumberOfRowsInColumnZero2@Class1@cppClassLib@@SEHHQAUcolumnT2@12@@Z")]
        public static extern int getMatrixNumberOfRowsInColumnZero2(int maxColumns,
            [MarshalAs(UnmanagedType.LPArray,
            SizeParamIndex = 0,
            ArraySubType = UnmanagedType.Struct)]
            columnType2[] matrix);
        /*
        [DllImport("kernel32.dll")]
        static extern IntPtr GlobalAlloc(uint uFlags, uint dwBytes);
        const uint GMEM_FIXED = 0x0000;
        const uint GMEM_ZEROINIT = 0x0040;
        const uint GPTR = GMEM_FIXED | GMEM_ZEROINIT;
        */
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Text = getInt().ToString();
            label1.Text = getHi2();
            listView1.Items.Clear();
            listView1.Items.Add(label1.Text);
            //listView1.
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = getHi();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            const int maxsize = 2;
            String[] headerList = new String[maxsize];
            int len = getHeaderListTwo(maxsize, ref headerList);
            MessageBox.Show("Got length " + headerList.Length+" ("+len+")");
            label1.Text="";
            for (int i = 0; i < headerList.Length; ++i)
            {
                if (headerList[i].Length>0)
                {
                    label1.Text += headerList[i].ToString() + " // ";
                }
                else
                {
                    label1.Text += " // ";
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int maxColumns=5;
            int numberOfColumns = 0;
            columnType[] matrix = new columnType[maxColumns];
            for (int i = 0; i < maxColumns; ++i)
            {
                matrix[i] = new columnType();
            }
            matrix[0].numberOfRows = 1; // pick something just to see if we can get it back
            matrix[0].columnName = "ABC";
            // numberOfRows must be less than or equal to maxRows
            columnType2[] matrix2 = new columnType2[maxColumns];
            for (int i = 0; i < maxColumns; ++i)
            {
                matrix2[i] = new columnType2();
            }
            matrix2[0].numberOfRows = 1; // pick something just to see if we can get it back
            
            //uint sz = (uint)maxColumns*4;
            //IntPtr matrixIP = GlobalAlloc(GPTR, sz);
            //columnType[] matrix = matrixIP;
            //IntPtr pointerArr = Marshal.AllocHGlobal(maxColumns*4);
            //int result = getMatrixNumberOfRowsInColumnZero(maxColumns,matrix);
            //label1.Text = result.ToString();
            numberOfColumns = getMatrix(maxColumns, maxRows, ref matrix);
            label1.Text = matrix[0].columnName;
        }
    }
    }
