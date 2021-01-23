    internal sealed class GameGrid : ContainerControl
    {
        protected override void OnCreateControl()
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    GameButton button = new GameButton
                    {
                        Width = Width/3,
                        Height = Height/3,
                    };
    
                    button.Location = new Point(x*button.Width++, y*button.Height++);
                    Controls.Add(button);
    
                    button.Click += button_Click;
                }
            }
        }
    
        static void button_Click(object sender, EventArgs e)
        {
            GameButton gameButton = (GameButton)sender;
            gameButton.CircleCheck = true;
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(ClientRectangle.Location, new Size(Width - 1, Height - 1)));
        }
    }
    
    internal sealed class GameButton : Control
    {
        private bool _cricleCheck;
        public bool CircleCheck 
        { 
            get
            {
                return _cricleCheck;
            } 
            set 
            {
                _cricleCheck = value;
                Invalidate();
            } 
        }
    
        private readonly Pen circlePen = new Pen(Brushes.Black, 2.0f);
    
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(ClientRectangle.Location, new Size(Width - 1, Height - 1)));
    
            if (CircleCheck)
            {
                e.Graphics.DrawEllipse(circlePen, new Rectangle(ClientRectangle.Location.X + 10, ClientRectangle.Location.Y + 10, Width - 30, Height - 30));
            }
        }
    }
