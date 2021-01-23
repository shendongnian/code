        #region Codes for browsing for a picture
        /// <summary>
        /// this.picStudent the name of the Image Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStudentPic_Click(object sender, EventArgs e)
        {
            Image picture = (Image)BrowseForPicture();
            this.picStudent.Image = picture;
            this.picStudent.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Bitmap BrowseForPicture()
        {
           // Bitmap picture = null;
            try
            {
                if (this.fdlgStudentPic.ShowDialog() == DialogResult.OK)
                {
                    byte[] imageBytes = File.ReadAllBytes(this.fdlgStudentPic.FileName);
                    StudentPic = new Bitmap( this.fdlgStudentPic.FileName);
                    StuInfo.StudentPic = imageBytes;
                }
                else
                {
                    StudentPic = Properties.Resources.NoPhotoAvailable;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("That was not a picture.", "Browse for picture");
                StudentPic = this.BrowseForPicture();
            }
            return StudentPic;
        }
        #endregion
