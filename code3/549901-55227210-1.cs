        private void button8_Click_1(object sender, EventArgs e)
        {
            string uimode_previus = axWindowsMediaPlayer2.uiMode;
            axWindowsMediaPlayer2.uiMode = "none";
            
            
            
            if (!string.IsNullOrEmpty(axWindowsMediaPlayer2.URL))
            {
                ret = null;
                try
                {
                    // take picture BEFORE saveFileDialog pops up!!
                    Bitmap bitmap = new Bitmap(axWindowsMediaPlayer2.Width, axWindowsMediaPlayer2.Height);
                    {
                        Graphics g = Graphics.FromImage(bitmap);
                        {
                            Graphics gg = axWindowsMediaPlayer2.CreateGraphics();
                            {
                                //timerTakePicFromVideo.Start();
                                this.BringToFront();
                                g.CopyFromScreen(
                                    axWindowsMediaPlayer2.PointToScreen(
                                        new System.Drawing.Point()).X,
                                    axWindowsMediaPlayer2.PointToScreen(
                                        new System.Drawing.Point()).Y,
                                    0, 0,
                                    new System.Drawing.Size(
                                        axWindowsMediaPlayer2.Width-0,
                                        axWindowsMediaPlayer2.Height-0)
                                    );
                            }
                        }
                        // afterwards save bitmap file if user wants to
                        try
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                string rute = axWindowsMediaPlayer2.URL.ToString().Replace(".", "Review_."); // 
                                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                ret = new Bitmap(System.Drawing.Image.FromStream(ms));
                                ret.Save(rute.Replace(".mp4", ".Png"));
                            }
                            // open captured frame in new form
                            TeamEasy.ShowPictureForm spf = new ShowPictureForm();
                            spf.ImagePictureBox.Image = ret;
                            spf.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            
            axWindowsMediaPlayer2.uiMode = uimode_previus;  // restore the UImode of player
        }
