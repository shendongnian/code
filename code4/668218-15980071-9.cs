    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication12
    {
        public partial class Form1 : Form
        {
            [DllImport("Shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
            static extern uint SHExtractIconsW(
                string pszFileName,
                int nIconIndex,
                int cxIcon,
                int cyIcon,
                IntPtr[] phIcon,
                uint[] pIconId,
                uint nIcons,
                uint flags
            );
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private IntPtr[] Icons;
            private int currentIcon = 0;
            uint iconsExtracted;
    
            private void Form1_Load(object sender, EventArgs e)
            {
                uint nIcons = 1000;
                Icons = new IntPtr[nIcons];
                uint[] IconIDs = new uint[nIcons];
                iconsExtracted = SHExtractIconsW(
                    @"C:\Windows\System32\shell32.dll",
                    0,
                    256, 256,
                    Icons,
                    IconIDs,
                    nIcons,
                    0
                );
                if (iconsExtracted == 0)
                    ;//handle error
                Text = string.Format("Icon count: {0:d}", iconsExtracted);
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                pictureBox1.Image = Bitmap.FromHicon(Icons[currentIcon]);
                currentIcon = (currentIcon + 1) % (int)iconsExtracted;
            }
        }
    }
