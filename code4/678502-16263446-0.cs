     private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Modifiers == Keys.None && e.KeyCode == Keys.Delete)
                    UndoStack.Push(new UndoSection(richTextBoxPrintCtrl1.SelectionStart, richTextBoxPrintCtrl1.SelectedText));
                else if (e.Control && e.KeyCode == Keys.Z)
                {
                    e.Handled = true;
                    undo_Click(richTextBoxPrintCtrl1, new EventArgs());
                }
                else if (e.Control && e.KeyCode == Keys.Y)
                {
                    e.Handled = true;
                    redo_Click(richTextBoxPrintCtrl1, new EventArgs());
                }
