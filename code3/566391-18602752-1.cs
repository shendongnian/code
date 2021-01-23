        private void btnOrdered_Click(object sender, EventArgs e)
        {
            string[] splitSelection = null;
            // If selection split selection else split everything
            if (this.txtCaptionEditor.SelectionLength > 0)
            {
                splitSelection = this.txtCaptionEditor.SelectedText.Replace("\r\n", "\n").Split("\n".ToCharArray());
            }
            else
            {
                splitSelection = this.txtCaptionEditor.Text.Replace("\r\n", "\n").Split("\n".ToCharArray());
            }
            bool Exists = false;
            for (int i = 0; i < splitSelection.GetLength(0); i++)
            {
                // If Ordered List Allready exists in selection then remove else add
                if (!string.IsNullOrEmpty(splitSelection[i]))
                {
                    if (splitSelection[i].Substring(0, 2) == "1.") { Exists = true; }
                }
            }
            for (int i = 0; i < splitSelection.GetLength(0); i++)
            {
                int lineCount = (i + 1);
                if (Exists)
                {
                    this.txtCaptionEditor.Text = this.txtCaptionEditor.Text.Replace(Convert.ToString(lineCount) + ".  ", "");
                }
                else
                {
                    if(!string.IsNullOrEmpty(splitSelection[i]))
                    {
                        this.txtCaptionEditor.Text = this.txtCaptionEditor.Text.Replace(splitSelection[i], Convert.ToString(lineCount) + ".  " + splitSelection[i]);
                    }
                    
                }
            }
        }
        private void txtCaptionEditor_KeyDown(object sender, KeyEventArgs e)
        {
            string[] splitSelection = this.txtCaptionEditor.Text.Replace("\r\n", "\n").Split("\n".ToCharArray());
            if (e.KeyCode == Keys.Enter)
            {
                // Get Current Line Position
                int currentLine = this.txtCaptionEditor.GetLineFromCharIndex(this.txtCaptionEditor.SelectionStart);
                // Only Run if the previous line is greater than zero
                if ((currentLine) >= 0)
                {
                    // Loop through 100 possible numbers for match you can go higher 
                    // If you think your numbered list could go above 100
                    for (int i = 0; i < 100; i++)
                    {
                        if (splitSelection[(currentLine)].Substring(0, 2) == Convert.ToString((i + 1)) + ".")
                        {
                            // If the substring of the current line equals a numbered list                value.. enumerate next line
                            this.txtCaptionEditor.SelectedText = "\n" + (i + 2) + ".  ";
                            e.SuppressKeyPress = true;
                        }
                    }
                }
            }
        }
