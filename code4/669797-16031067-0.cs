        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(RenderProgressbarImage(e.Graphics), new Point(5, 5));
            //Test to Check for Output
            RenderProgressbarImage(e.Graphics).Save(@"C:\Bitmap.bmp");;
            
            //following code works good
            progressRenderer.SetParameters("PROGRESS", 11, 2);
            progressRenderer.DrawBackground(e.Graphics, new Rectangle(125, 5, 100, 13));
        }
        Bitmap RenderProgressbarImage(Graphics g)
        {
            Bitmap bmp = new Bitmap(100, 13, g);
            progressRenderer.SetParameters("PROGRESS", 11, 2);
            progressRenderer.DrawBackground(g, new Rectangle(0, 0, bmp.Width, bmp.Height));
            return bmp;
        }
