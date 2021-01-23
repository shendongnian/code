    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using StackOverflow.Extensions;
    using System.Runtime.InteropServices;
    using System.IO;
    using Microsoft.Win32.SafeHandles;
    
    namespace StackOverflow
    {
        public partial class FormMain : Form
        {
            [DllImport("kernel32.dll",
                EntryPoint = "GetStdHandle",
                SetLastError = true,
                CharSet = CharSet.Auto,
                CallingConvention = CallingConvention.StdCall)]
            private static extern IntPtr GetStdHandle(int nStdHandle);
    
            [DllImport("kernel32.dll",
                EntryPoint = "AllocConsole",
                SetLastError = true,
                CharSet = CharSet.Auto,
                CallingConvention = CallingConvention.StdCall)]
            private static extern int AllocConsole();
    
            // Some constants
            private const int STD_OUTPUT_HANDLE = -11;
            private const int MY_CODE_PAGE = 437;
    
            public FormMain()
            {
                InitializeComponent();
            }
    
            public void PrepareConsole()
            {
                AllocConsole();
                IntPtr stdHandle = GetStdHandle(STD_OUTPUT_HANDLE);
                SafeFileHandle safeFileHandle = new SafeFileHandle(stdHandle, true);
                FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
                Encoding encoding = System.Text.Encoding.GetEncoding(MY_CODE_PAGE);
                StreamWriter standardOutput = new StreamWriter(fileStream, encoding);
                standardOutput.AutoFlush = true;
                Console.SetOut(standardOutput);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // Console was not visible before this button click
                Console.WriteLine("This text is written to the console that just popped up.");
    
                MessageBox.Show("But we're still in a Windows Form application.");
            }
        }
    }
