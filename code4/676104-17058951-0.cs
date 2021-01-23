     if (Document.SelectionFont != null)
            {
                tb_Bold.Checked = Document.SelectionFont.Bold;
                tb_Italic.Checked = Document.SelectionFont.Italic;
                tb_UnderLine.Checked = Document.SelectionFont.Underline;
                tb_FontSize.Text = Document.SelectionFont.SizeInPoints.ToString();
                tb_Font.Text = Document.SelectionFont.FontFamily.Name;
                if (Document.SelectionAlignment.ToString() == "Right")
                {
                    Center.Checked = false;
                    Right.Checked = true;
                    Left.Checked = false;
                }
                else if (Document.SelectionAlignment.ToString() == "Center")
                {
                    Center.Checked = true;
                    Right.Checked = false;
                    Left.Checked = false;
                }
                else
                {
                    Center.Checked = false;
                    Right.Checked = false;
                    Left.Checked = true;
                }
            
            }
