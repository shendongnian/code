        private int move(int n, int a, int currentFib)
        {
            switch (a)
            {
                case 1: return currentFib;
                case 2: return -fib(n - 1) * ZOOM;
                case 3: return -fib(n + 1) * ZOOM;
                default: return 0;
            }
        }
        private void drawSpiral()
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                Rectangle r = new Rectangle(0, 0, 0, 0);
                int x = CENTERX;
                int y = CENTERY;
                for (int n = 1; n <= FIBNUM; n++)
                {
                    int fibnum = fib(n)*ZOOM;
                    r = new Rectangle(x, y, fibnum, fibnum);
                    g.DrawRectangle(Pens.Red, r);
                    x += move(n, n % 4, fibnum);
                    y += move(n, (n + 1) % 4, fibnum);
                }
                pictureBox1.Invalidate();
            }
        }
