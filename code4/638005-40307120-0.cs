    using System;
    using System.Windows.Forms;
    namespace Clicker
    {
        public partial class Form1 : Form
        {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private const int MOUSEEVENT_LEFTDOWN = 0x02;
        private const int MOUSEEVENT_LEFTUP = 0x04;
        private const int MOUSEEVENT_MIDDLEDOWN = 0x20;
        private const int MOUSEEVENT_MIDDLEUP = 0x40;
        private const int MOUSEEVENT_RIGHTDOWN = 0x08;
        private const int MOUSEEVENT_RIGHTUP = 0x10;
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            label2.Text = "Timer is on";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label2.Text = "Timer is off";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
            count++;
            label3.Text = count + " amount of clicks";
        }
        
    }
}
