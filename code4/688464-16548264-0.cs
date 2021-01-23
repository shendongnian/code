    public partial class Form1 : Form
    {
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // call render function
            RenderGraphics(e.Graphics, pictureBox1.ClientRectangle);
        }
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            // refresh drawing on resize
            pictureBox1.Refresh();
        }
        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create a memory image with the size taken from the picturebox dimensions
            RectangleF client=new RectangleF(
                0, 0, pictureBox1.Width, pictureBox1.Height);
            Image img=new Bitmap((int)client.Width, (int)client.Height);
            // create a graphics target from image and draw on the image
            Graphics g=Graphics.FromImage(img);
            RenderGraphics(g, client);
            // copy image to clipboard.
            Clipboard.SetImage(img);
        }
        private void RenderGraphics(Graphics g, RectangleF client)
        {
            g.SmoothingMode=SmoothingMode.AntiAlias;
            // draw code goes here
        }
    }
