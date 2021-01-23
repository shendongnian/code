           private void pbOriginalImage_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                // Starting point of the selection:
                if (e.Button == MouseButtons.Left)
                {
                    _selecting = true;
                    _selection = new Rectangle(new Point(e.X, e.Y), new Size());
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }
        private void pbOriginalImage_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                // Update the actual size of the selection:
                if (_selecting)
                {
                    _selection.Width = e.X - _selection.X;
                    _selection.Height = e.Y - _selection.Y;
                    // Redraw the picturebox:
                    pbOriginalImage.Refresh();
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }
        private void pbOriginalImage_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (pbOriginalImage.Image == null)
                    return;
                if (e.Button == MouseButtons.Left && _selecting)
                {
                    // check selection rectangle has non-zero Height and Width
                    if (!ValidateSelection(_selection))
                    {
                        _selecting = false;
                        return;
                    }
                    // Check that selection rectangle does extend outside of image boundaries
                    ValidateRectangleSize();
                    // Create cropped image:
                    Image tempImage = pbOriginalImage.Image.Clone() as Image;
                    Image img = tempImage.Crop(_selection);
                   
                    // Fit image to the picturebox:
                    profileImage.Image = img.Fit2PictureBox(profileImage);
                    _selecting = false;
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }
        private void pbOriginalImage_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (_selecting)
                {
                    // Draw a rectangle displaying the current selection
                    Pen pen = Pens.GreenYellow;
                    e.Graphics.DrawRectangle(pen, _selection);
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
                throw;
            }
        }
        private void commandBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|bmp Files (*.bmp)|*.bmp|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo file = new FileInfo(dlg.FileName);
                        if (file.Length == 0)
                        {
                            MessageBoxEx.Show("Invalid image. Please select valid image.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else if (file.Length > 2097152)
                        {
                            MessageBoxEx.Show("Image size cannot exceed 2MB.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        textProfileImagePath.Text = dlg.FileName;
                        pbOriginalImage.Image = Image.FromFile(dlg.FileName).Fit2PictureBox(pbOriginalImage);
                        profileImage.Image = Image.FromFile(dlg.FileName).Fit2PictureBox(profileImage);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Out of memory"))
                {
                    MessageBoxEx.Show("Invalid image. Please select valid image.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    ApplicationExceptions.HandleAppExc(ex);
            }
        }
        // Check that selection rectangle does extend outside of image boundaries
        private void ValidateRectangleSize()
        {
            Size imgSize = this.pbOriginalImage.Image.Size;
            int selectionWidth;
            int selectionHeight;
            // check width
            if (_selection.X < 0)
            {
                _selection.X = 0;
            }
            selectionWidth = _selection.Width + _selection.X;
            if (selectionWidth > imgSize.Width)
            {
                _selection.Width = imgSize.Width - _selection.X - 1;
            }
            // check height
            if (_selection.Y < 0)
            {
                _selection.Y = 0;
            }
            selectionHeight = _selection.Height + _selection.Y;
            if (selectionHeight > imgSize.Height)
            {
                _selection.Height = imgSize.Height - _selection.Y - 1;
            }
        }
        // check selection rectangle has non-zero Height and Width
        private bool ValidateSelection(Rectangle selection)
        {
            // routine to validate the selection
            if (selection.Width <= 0 || selection.Height <= 0)
            {
                // if you get here a good rectangle was not created
                return false;
            }
            else
            {
                return true;
            }
        }
