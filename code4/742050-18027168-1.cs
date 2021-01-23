            else if (e.KeyCode == Keys.Down)
            {
                if (lst.SelectedIndex + 1 < lst.Items.Count)
                {
                    lst.SelectedIndex += 1; 
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (lst.SelectedIndex - 1 >= 0)
                {
                    lst.SelectedIndex -= 1;
                }
                e.Handled = true;
            }
