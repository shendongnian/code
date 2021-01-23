    using System.Drawing;
    using System.Windows.Forms;
    
    public class ExPanel : Panel
    {
        public Image image
        {
            get;
            set;
        }
    
        public ExPanel()
        {
            addPic();
        }
    
        private void addPic()
        {
            PictureBox pic = new PictureBox();
            pic.Top = 10; pic.Left = 10;
            pic.Width = 100;
            pic.Height = 100;
            pic.BackColor = Color.Blue;
            if (this.image != null) pic.Image = this.image;
            this.Controls.Add(pic);
        }
    }
