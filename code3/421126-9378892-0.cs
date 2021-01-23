    private void btnScreenShot_Click(object sender, EventArgs e)
            {
                // Freezes here
                btnSave.Visible = true;
                while(flag == 0)
                {
                     Application.DoEvents();
                     sendto_bmpbox.Image = CaptureScreen();
                }
            }
