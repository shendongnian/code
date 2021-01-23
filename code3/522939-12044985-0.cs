        public partial class Form1 : Form
    {
        private FrameDimension dimension;
        private int frameCount;
        private int indexToPaint;
        private Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            dimension = new FrameDimension(this.pictureBox1.Image.FrameDimensionsList[0]);
            frameCount = this.pictureBox1.Image.GetFrameCount(dimension);
            this.pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint); 
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            indexToPaint++;
            if(indexToPaint >= frameCount)
            {
                indexToPaint = 0;
            }
        }
        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            this.pictureBox1.Image.SelectActiveFrame(dimension, indexToPaint);
            e.Graphics.DrawImage(this.pictureBox1.Image, Point.Empty);
        }
    }
