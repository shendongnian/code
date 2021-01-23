     private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            
            try
            {
                pictureBox1.Image = null;
                string[] filename = (string[])e.Data.GetData(DataFormats.FileDrop);
                pictureBox1.Image = Image.FromFile(filename[0]);
            }
            catch (Exception expr)
            { }
        }
