    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1() { InitializeComponent(); }
            private void Form1_Load(object sender, EventArgs e)
            {
                // create image to which we will draw
                var img = new Bitmap(100, 100);
                // get a Graphics object via which we will draw to the image
                var g = Graphics.FromImage(img);
                // create event args with the graphics object
                var pea = new PaintEventArgs(g, new Rectangle(new Point(0,0), new Size(100,100)));
                // call DoPaint method of our inherited object
                btnTarget.DoPaint(pea);
                // display the result in a picture box for testing and proof
                pictureBox.BackgroundImage = img;
            }
        }
        public class MyButton : Button
        {
            // wrapping InvokePaint via a public method
            public void DoPaint(PaintEventArgs pea)
            {
                InvokePaint(this, pea);
            }
        }
    }
