    private void richTextBox2_MouseMove(object sender, MouseEventArgs e)
            {
                int c = richTextBox2.GetCharIndexFromPosition(new Point(e.X, e.Y));
                richTextBox2.Select(c, 1);
                if (richTextBox2.SelectionFont.Bold)
                {
                    richTextBox2.Cursor = Cursors.Hand;
                }
                else
                {
                    richTextBox2.Cursor = Cursors.Default;
                }
    
            }
