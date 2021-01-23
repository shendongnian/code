     private void rtb_KeyDown(object sender, KeyEventArgs e)
        {
            // Trick to build undo stack word by word
            RichTextBox rtb = (RichTextBox)sender;
            if (e.KeyCode == Keys.Space)
            {
                this.SuspendLayout();
                rtb.Undo();
                rtb.Redo();
                this.ResumeLayout();
            }
            // eztnap
        }
