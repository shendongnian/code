    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class ImageButton : PictureBox
    {
        private Image _upImage, _downImage;
        [System.ComponentModel.Browsable(true),
         System.ComponentModel.Category("Images")]
        public Image UpImage
        {
            get { return _upImage; }
            set
            {
                if (value != null)
                {
                    _upImage = value;
                    this.Image = _upImage;
                }
            }
        }
        [System.ComponentModel.Browsable(true),
         System.ComponentModel.Category("Images")]
        public Image DownImage
        {
            get { return _downImage; }
            set
            {
                if (value != null)
                {
                    _downImage = value;
                }
            }
        }
        public ImageButton()
        {
            InitializeComponent();
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TabStop = false;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (DownImage != null)
                this.Image = DownImage;
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (UpImage != null)
                this.Image = UpImage;
            base.OnMouseUp(e);
        }
    }
