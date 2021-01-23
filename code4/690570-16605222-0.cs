        private void textbox1_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point curpos = e.GetPosition(textbox1);
            int pos1;
            pos1 = textbox1.GetCharacterIndexFromPoint(curpos, true);
            label1.Content = pos1.ToString();
        }
