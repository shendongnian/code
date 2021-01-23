        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle client=new Rectangle(0, 0, ClientSize.Width-1, ClientSize.Height-1);
            Render(e.Graphics, client);
        }
        public void Render(Graphics g, Rectangle client)
        {
            g.DrawEllipse(Pens.Blue, client); //test draw
            //...
        }
