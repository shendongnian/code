    using System;
    using System.Threading;
    using System.Windows.Forms;
    using Media;
    
    public partial class AITL : Form
    {
        AudioInputToolbox atr = new AudioInputToolbox();
    
        public AITL()
        {
            InitializeComponent();
        }
    
        private void startButton_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                atr.BeginReading(0);
                atr.BeginLoopback();
            }).Start();              
        }
    
        private void stopButton_Click(object sender, EventArgs e)
        {
            atr.EndReading();
            atr.EndLoopback();
        }
    }
