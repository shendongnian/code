        private void chkMyCheckBoxWithAnImage_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMyCheckBoxWithAnImage.Checked)
                chkIsConsistent.ImageIndex = 1;
            else
                chkIsConsistent.ImageIndex = 0;
        }
