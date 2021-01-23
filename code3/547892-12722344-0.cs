		string strOrgFullPath = "";
		private void button1_Click(object sender, EventArgs e)
        {
            dlg.Filter = "Image (*bmp)|*.bmp|All Files|*.*";
            SetLogo = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               this.pictureBox1.Image = (System.Drawing.Bitmap)Image.FromFile(dlg.FileName);
               int nMaxBitmapHeigth = 800;
               int nMaxBitmapWidth = 950;
                strOrgFullPath = dlg.FileName;
                System.Drawing.Bitmap bmpNew = new System.Drawing.Bitmap(strOrgFullPath);
                System.Drawing.Bitmap bmpOrg = null;
          // after this is the code for resizing the image to show on another picture box.
        }
		private void comboBox44_SelectedIndexChanged(object sender, EventArgs e)
		{
			int nMaxBitmapHeigth = 800;
			int nMaxBitmapWidth = 950;
			System.Drawing.Bitmap bmpNew = new System.Drawing.Bitmap(strOrgFullPath);
			System.Drawing.Bitmap bmpOrg = null;
		// after this is the code for resizing the image to show on another picture box.
		}
       Try, Best of luck
