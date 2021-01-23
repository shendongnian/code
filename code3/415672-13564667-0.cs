      private void lstFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)   //(1)
            {
                int indexOfItemUnderMouseToDrag;
                indexOfItemUnderMouseToDrag = lstFiles.IndexFromPoint(e.X, e.Y); //(2)
                if (indexOfItemUnderMouseToDrag != ListBox.NoMatches)
                {
                    lstFiles.SelectedIndex = indexOfItemUnderMouseToDrag; //(3)
                }
            }
        }
