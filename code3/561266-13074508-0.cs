    internal class TransparentWholeScreen: Form
    {
        public TransparentWholeScreen()
        {
            Size = Screen.PrimaryScreen.Bounds.Size;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Shown += OnShown;
        }
    
        private void OnShown(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("text", "caption", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.OK)
            {
                Close();
            }
        }
    }
