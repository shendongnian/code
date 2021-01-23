    class MyDataGridView : DataGridView
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == Keys.Enter) && (this.EditingControl != null))
            {
                TextBox tb = (TextBox)EditingControl;
                int pos = tb.SelectionStart;
                tb.Text = tb.Text.Remove(pos, tb.SelectionLength);
                tb.Text = tb.Text.Insert(pos, Environment.NewLine);
                tb.SelectionStart = pos + Environment.NewLine.Length;
                tb.ScrollToCaret();
                return true;
            }
            else if (keyData == Keys.Up)
            {
                TextBox tb = (TextBox)EditingControl;
                int pos = tb.SelectionStart;
                int lineNo = tb.GetLineFromCharIndex(pos);
                if (lineNo > 0)
                {
                    int linePos = pos - tb.GetFirstCharIndexOfCurrentLine();
                    int newPos;
                    if (linePos > tb.Lines[lineNo - 1].Length)
                        newPos = tb.GetFirstCharIndexFromLine(lineNo - 1) + tb.Lines[lineNo - 1].Length;
                    else
                        newPos = tb.GetFirstCharIndexFromLine(lineNo - 1) + linePos;
                    tb.SelectionStart = newPos;
                    tb.ScrollToCaret();
                }
                return true;
            }
            else if (keyData == Keys.Down)
            {
                TextBox tb = (TextBox)EditingControl;
                int pos = tb.SelectionStart;
                int lineNo = tb.GetLineFromCharIndex(pos);
                if (lineNo < tb.Lines.Count() - 1)
                {
                    int linePos = pos - tb.GetFirstCharIndexOfCurrentLine();
                    int newPos;
                    if (linePos > tb.Lines[lineNo + 1].Length)
                        newPos = tb.GetFirstCharIndexFromLine(lineNo + 1) + tb.Lines[lineNo + 1].Length;
                    else
                        newPos = tb.GetFirstCharIndexFromLine(lineNo + 1) + linePos;
                    tb.SelectionStart = newPos;
                    tb.ScrollToCaret();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
