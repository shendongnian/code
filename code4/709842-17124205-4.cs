    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private bool _altF4Pressed = false;
    
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Alt && e.KeyCode == Keys.F4)
                    _altF4Pressed = true;
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                //show the MessageBox asking the user if the programm should really exit
                //MessageBoxQueryClose msgBoxQC = new MessageBoxQueryClose();
                //msgBoxQC.QueryClose(ref _altF4Pressed, ref timer2, ref e);
    
                if (_altF4Pressed)
                {
                    this.timer2.Stop();
                    if (MessageBox.Show("Close program ?", "timers",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        e.Cancel = true;
                        this.timer2.Start();
                    }
    
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                timer1.Interval = 20;
                timer1.Enabled = true;
    
                timer2.Interval = 1000;
                timer2.Enabled = true;
            }
    
    
            bool toggle = false;
    
            private void timer2_Tick(object sender, EventArgs e)
            {
                if (toggle)
                    label1.Text = "tick";
                else
                    label1.Text = "tack";
    
                toggle = !toggle;
            }
    
    
            //Point oldPos, newPos;
    
            private void timer1_Tick(object sender, EventArgs e)
            {
    
                label2.Text = MousePosition.X.ToString() + " , " + MousePosition.Y.ToString();
            }
    
            //private void CompareCursorPosition()
            //{
            //    if (oldPos != newPos)
            //        Display_ResetFallback();
            //}
    
            //private void Display_ResetFallback()
            //{
            //    timer2.Stop();
            //    timer2.Start();
            //}
        }
