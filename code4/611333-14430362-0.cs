    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private Timer timer;
    
            private Bitmap dice;
    
            private int[] currentValues = new int[6];
    
            private Random random = new Random();
    
            public Form1()
            {
                InitializeComponent();
                this.timer = new Timer();
                this.timer.Interval = 500;
                this.timer.Tick += TimerOnTick;
    
                this.dice = Properties.Resources.Dice;
            }
    
            private void TimerOnTick(object sender, EventArgs eventArgs)
            {
                for (var i = 0; i < currentValues.Length; i++)
                {
                    this.currentValues[i] = this.random.Next(1, 7);
                }
    
                this.panel1.Invalidate();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (this.timer.Enabled)
                {
                    this.timer.Stop();
                }
                else
                {
                    this.timer.Start();
                }
            }
    
            private void panel1_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.Clear(Color.White);
    
                if (this.timer.Enabled)
                {
                    for (var i = 0; i < currentValues.Length; i++)
                    {
                        e.Graphics.DrawImage(this.dice, new Rectangle(i * 70, 0, 60, 60), 0, (currentValues[i] - 1) * 60, 60, 60, GraphicsUnit.Pixel);
                    }
                }
            }
        }
    }
