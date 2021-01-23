    public class FramedPictureBox : UserControl
    {
        private readonly PictureBox _pictureBox;
        public FramedPictureBox()
        {
            const int FRAME_SIZE = 3;
            _pictureBox = new PictureBox
                              {
                                  Left = FRAME_SIZE,
                                  Top = FRAME_SIZE,
                                  Width = Width - 2*FRAME_SIZE,
                                  Height = Height - 2*FRAME_SIZE,
                                  Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top
                              };
            _pictureBox.MouseEnter += OnPictureBoxMouseEnter;
            _pictureBox.MouseLeave += OnPictureBoxMouseLeave;
            Controls.Add(_pictureBox);
        }
        protected override void OnLoad(EventArgs e)
        {
            var image = new Bitmap(_pictureBox.Width, _pictureBox.Height);
            var graphics = Graphics.FromImage(image);
            graphics.Clear(Color.White);
            _pictureBox.Image = image;
            base.OnLoad(e);
        }
        private void OnPictureBoxMouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.Red;
        }
        private void OnPictureBoxMouseLeave(object sender, EventArgs e)
        {
            BackColor = SystemColors.Control;
        }
    }
