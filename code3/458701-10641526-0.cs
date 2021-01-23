        private void DrawGame()
        {
            DrawSprite1(Graphics.FromImage(screen1));
            DrawSprite2(Graphics.FromImage(screen2));
        }
        public void DrawSprite1(Graphics g)
        {
            g.FillEllipse(Pens.Blue, screen1.GetBounds());
        }
        public void DrawSprite2(Graphics g)
        {
            g.FillRect(Brushes.Red, screen2.GetBounds());
        }
