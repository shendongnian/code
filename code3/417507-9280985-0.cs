namespace TestImage
{
    public partial class ImageControl : UserControl
    {
        public ImageControl()
        {
            InitializeComponent();
            
            /// image.png should be placed in the IDE folder or use the fullpath/url instead and also in the output directory.
            this.pictureBox1.ImageLocation = @".\image.png";
        }
    }
}
