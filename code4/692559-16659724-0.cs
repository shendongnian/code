            int LineNumber = 6;
            TextBox TB = (TextBox)tabControl1.SelectedTab.Controls[0];
            int position = 0;
            for (int i = 1; i <= TB.Lines.Length && i < LineNumber; i++)
            {
                position += TB.Lines[i - 1].Length + Environment.NewLine.Length;
            }
            TB.Focus();
            TB.SelectionStart = position;
            TB.SelectionLength = 0;
            TB.ScrollToCaret();
