    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class ImageButton : PictureBox
    {
        private Image _upImage, _downImage, _hoverImage;
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
        [System.ComponentModel.Browsable(true),
         System.ComponentModel.Category("Images")]
        public Image HoverImage
        {
            get { return _hoverImage; }
            set
            {
                if (value != null)
                {
                    _hoverImage = value;
                }
            }
        }
        public ImageButton()
        {
            InitializeComponent();
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
        protected override void OnMouseEnter(EventArgs e)
        {
            if (HoverImage != null)
                this.Image = HoverImage;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            if (UpImage != null)
                this.Image = UpImage;
            base.OnMouseLeave(e);
        }
    }
What I have done is inherrited from the standard PictureBoxto make an ImageButton.  I have three properties for the Image to display with no mouse action (UpImage), the Image to display when the MouseDown event is triggered (DownImage), and the Image to display when the mouse is hovering over the control (HoverImage).
