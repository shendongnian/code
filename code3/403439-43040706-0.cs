    using System;
    using System.Runtime.InteropServices; //Reference for Cue Banner
    using System.Windows.Forms;
    namespace Your_Project
    {
        public partial class Form1 : Form
        {
            private const int TB_SETCUEBANNER = 0x1501; //Textbox Integer
            private const int CB_SETCUEBANNER = 0x1703; //Combobox Integer
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern Int32 SendMessage(IntPtr hWnd, int msg,
                int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam); //Main Import for Cue Banner
    
            public Form1()
            {
                InitializeComponent();
                SendMessage(textBox1.Handle, TB_SETCUEBANNER, 0, "Type Here..."); //Cue Banner for textBox1
                SendMessage(comboBox1.Handle, CB_SETCUEBANNER, 0, "Type Here..."); //Cue Banner for comboBox1
            }
