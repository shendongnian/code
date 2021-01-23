    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    namespace CreateImageList
    {
    public partial class Form1 : Form
    {
        private int currentImage = 0;
        protected Graphics myGraphics;
        ImageList iPicList = new ImageList();
        public Form1()
        {
            InitializeComponent();
            DirectoryInfo dirImages = new DirectoryInfo("C:\\2012");
            iPicList.ImageSize = new Size(255, 255);
            iPicList.TransparentColor = Color.White;
            myGraphics = Graphics.FromHwnd(panel1.Handle);
            foreach (FileInfo file in dirImages.GetFiles())
            {
                if (file.Extension == ".jpg")
                {
                    Image myImage = Image.FromFile(file.FullName);
                    iPicList.Images.Add(myImage);
                }
            }
            if (iPicList.Images.Empty != true)
            {
                panel1.Refresh();
                currentImage = 0;
                // Draw the image in the panel.
                iPicList.Draw(myGraphics, 1, 1, currentImage);
                // Show the image in the PictureBox.
                pictureBox1.Image = iPicList.Images[currentImage];
                label1.Text = "Image #" + currentImage;
            }
        }
        private void showImage(int imgIndex)
        {
            // Draw the image in the panel.
            iPicList.Draw(myGraphics, 1, 1, currentImage);
            // Show the image in the PictureBox.
            pictureBox1.Image = iPicList.Images[currentImage];
            label1.Text = "image #" + currentImage;
            panel1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (iPicList.Images.Count - 1 > currentImage)
            {
                currentImage++;
            }
            else
            {
                currentImage = 0;
            }
            showImage(currentImage);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (iPicList.Images.Count - 1 >= currentImage)
            {
                if (currentImage == 0)
                    currentImage = iPicList.Images.Count-1;
                else
                    currentImage--;
            }
            else
            {
                currentImage = iPicList.Images.Count;
            }
            showImage(currentImage);
        }
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Picture Box Double clicked");
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            myGraphics.DrawRectangle(Pens.Black, 0, 0, iPicList.Images[currentImage].Width + 1, iPicList.Images[currentImage].Height + 1);
            pictureBox1.Image = iPicList.Images[currentImage];
        }
    }
    }
