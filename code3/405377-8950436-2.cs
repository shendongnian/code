    public partial class Animation : Form
    {
        Image img1 = Properties.Resources.img1;
        Image img2 = Properties.Resources.img2;
        Image img3 = Properties.Resources.img3;
        List<Image> images = new List<Image>();
        Timer timer = new Timer();
        public Animation()
        {
            InitializeComponent();
            timer.Interval = 250;
            timer.Tick += new EventHandler(timer_Tick);
            images.Add(img1);
            images.Add(img2);
            images.Add(img3);
            animated_pbx.Image = img1;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(timer_Tick));
            }
            else
            {
                // Loop through the images unless we've reached the final one, in that case stop the timer
                Image currentImage = animated_pbx.Image;
                int currentIndex = images.IndexOf(currentImage);
                if (currentIndex < images.Count - 1)
                {
                    currentIndex++;
                    animated_pbx.Image = images[currentIndex];
                    animated_pbx.Invalidate();
                }
                else
                {
                    timer.Stop();
                }
            }
        }
        private void animated_pbx_MouseEnter(object sender, EventArgs e)
        {
            timer.Start();
        }
        private void animated_pbx_MouseLeave(object sender, EventArgs e)
        {
            timer.Stop();
            animated_pbx.Image = img1;
            animated_pbx.Invalidate();
        }
    }
