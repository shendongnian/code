    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.IO;
    namespace SwfRes
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                LoadBinSwf();
            }
            private void LoadBinSwf()
            {
                //Assuming your swf is called "Main.swf"
                byte[] swf = Properties.Resources.Main;
                MemoryStream memStream = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(memStream);
                writer.Write(8 + swf.Length);
                writer.Write(0x55665566);
                writer.Write(swf.Length);
                writer.Write(swf);
                memStream.Seek(0, SeekOrigin.Begin);
                axShockwaveFlash1.OcxState = new AxHost.State(memStream, 1, false, null);
            }
        }
    }
