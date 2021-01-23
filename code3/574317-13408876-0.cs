      public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                foreach (var p in Process.GetProcesses())
                {
                    if (p.MainWindowTitle.Contains("Move Mouse"))
                    {
                         IntPtr handle = p.MainWindowHandle;
                        if ((int)handle != 0)
                        {
                            Graphics g = Graphics.FromHwnd(handle);
                            g.FillRectangle(Brushes.Green, new Rectangle(0, 0, 10000, 10000));
                        }
                        
                    }
                }
            }
        }
