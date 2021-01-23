    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Threading;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Drawing.Text;
    using System.Text.RegularExpressions;
    using System.Configuration;
    using Microsoft.Win32;
    using System.Windows.Forms.VisualStyles;
    
    
    namespace FfplayTest
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    
            [DllImport("user32.dll")]
            private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    
            [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
            public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
    
    
            public Form1()
            {
                InitializeComponent();
                Application.EnableVisualStyles();
                this.DoubleBuffered = true;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            public Process ffplay = new Process();
            private void xxxFFplay()
            {
    
    
                ffplay.StartInfo.FileName = "ffplay.exe";
    
                string _argString = "-fflags nobuffer \"rtsp://admin:admin@192.168.0.163/live0.264\" -x 640 -y 480";
                string _newArgString = _argString.Replace("\",\"", ";");
                ffplay.StartInfo.Arguments = _newArgString;
                    
                ffplay.StartInfo.CreateNoWindow = true;
                ffplay.StartInfo.RedirectStandardOutput = true;
                ffplay.StartInfo.UseShellExecute = false;
    
                ffplay.EnableRaisingEvents = true;
                ffplay.OutputDataReceived += (o, e) => Debug.WriteLine(e.Data ?? "NULL", "ffplay");
                ffplay.ErrorDataReceived += (o, e) => Debug.WriteLine(e.Data ?? "NULL", "ffplay");
                ffplay.Exited += (o, e) => Debug.WriteLine("Exited", "ffplay");
                ffplay.Start();
                IntPtr intPtr = ffplay.MainWindowHandle;
                Thread.Sleep(200); // you need to wait/check the process started, then...
    
                // child, new parent
                // make 'this' the parent of ffmpeg (presuming you are in scope of a Form or Control)
                SetParent(ffplay.MainWindowHandle, this.Handle);
    
                // window, x, y, width, height, repaint
                // move the ffplayer window to the top-left corner and set the size to 320x280
                MoveWindow(ffplay.MainWindowHandle, 0, 0, 320, 280, true);
    
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                xxxFFplay();
            }
    
            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                try { ffplay.Kill(); }
                catch { }
            }
        }
    }
