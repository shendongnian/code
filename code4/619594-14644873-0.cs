    public void AddPictureBox(int x, int y)
        {
            try
            {
                PictureBox _picBox = new PictureBox();
                _picBox.Size = new Size(100, 100);
                _picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                _picBox.BackColor = Color.Black;
                _picBox.Location = new Point(x, y);
                _displayedImage.Add(_picBox);
    
                return _picBox;
    
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message); return null;
            }
        }
    private void MouseDown( object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pic = _testImage.AddPictureBox(e.X, e.Y);
                if(pic != null)
                {
                    this.Controls.Add(pic);
                    Trace.WriteLine("Picture box added");
                }
            }
    
            Trace.WriteLine("Mouse Click");
        }
