    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    namespace SSLP
    {
    public partial class Form1 : Form
    {
        [DllImport("SlpApi7x32.dll")]
        static extern void SlpDebugMode(int nMode);
        [DllImport("SlpApi7x32.dll")]
        static extern int SlpOpenPrinter(String strPrinterName, int nID, bool fPortrait);
        [DllImport("SlpApi7x32.dll")]
        static extern void SlpClosePrinter();
        [DllImport("SlpApi7x32.dll")]
        static extern bool SlpStartLabel();
        [DllImport("SlpApi7x32.dll")]
        static extern void SlpDrawTextXY(int x, int y, IntPtr iFont, String lpText);
        [DllImport("SlpApi7x32.dll")]
        static extern bool SlpEndLabel();
        [DllImport("SlpApi7x32.dll")]
        static extern IntPtr SlpCreateFont(String lpName, int nPoints, int nAttributes);
        [DllImport("GDI32.dll")]
        public static extern bool DeleteObject(IntPtr objectHandle); 
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            IntPtr font = SlpCreateFont("Arial", 10, 0);
            SlpDebugMode(2);
            //The second parameter defines the type of label per the documentation.
            SlpOpenPrinter("Smart Label Printer 440", 3, false);
            {
                SlpStartLabel();
                
                //Draw as much as you want with these!
                SlpDrawTextXY(0, 0, font, "Hello World");
                SlpEndLabel();
            }
            SlpClosePrinter();
            DeleteObject(font);
        }
    }
}
