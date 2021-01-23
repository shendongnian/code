    public partial class Form1 : Form
    {
        double OpacityStep = 0; 
        public Form1() 
        {            
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            this.Opacity = 1;
            OpacityStep = -0.10;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            double NewOpacity = Opacity + OpacityStep;
            if (NewOpacity <= 0)
            {
                NewOpacity = 0;
                OpacityStep = 0.10;
            }
            else if(NewOpacity >= 1 && OpacityStep  > 0)
            {
                NewOpacity = 1.0;
                button1.Enabled = true;
                timer1.Stop();
            }
            this.Opacity = NewOpacity;
        }
    }
