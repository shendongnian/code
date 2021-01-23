            this.rtxText.SelectionFont = new System.Drawing.Font(rtxText.Font.FontFamily,Convert.ToInt16(nudFontSize.Value), System.Drawing.FontStyle.Bold ^ this.rtxText.SelectionFont.Style);
        }
        //ITALICS CODING
        private void btnItalics_Click(object sender, EventArgs e)
        {
            this.rtxText.SelectionFont = new System.Drawing.Font(rtxText.Font.FontFamily, Convert.ToInt16(nudFontSize.Value), System.Drawing.FontStyle.Italic ^ this.rtxText.SelectionFont.Style);
        }
        //UNDERLINE CODING
        private void btnUnderline_Click(object sender, EventArgs e)
        {
            this.rtxText.SelectionFont = new System.Drawing.Font(rtxText.Font.FontFamily, Convert.ToInt16(nudFontSize.Value), System.Drawing.FontStyle.Underline ^ this.rtxText.SelectionFont.Style);
        }
